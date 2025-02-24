using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase;
using Supabase.Core;
using Supabase.Postgrest;
using TutormatchWeb.Models;

namespace TutormatchWeb.Services
{
    public class SupabaseService
    {
        private readonly Supabase.Client _supabase;
        private const string SUPABASE_URL = "https://gzpcygghvfeekuozowtv.supabase.co";
        private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imd6cGN5Z2dodmZlZWt1b3pvd3R2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzY3MDQzMjksImV4cCI6MjA1MjI4MDMyOX0.9oqFAFOPB-GmZtxQ_s1olGJ4pmyCMlAXuAy0rZ2PC3w";

            public SupabaseService()
            {
                var options = new SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true
                };

                _supabase = new Supabase.Client(SUPABASE_URL, SUPABASE_KEY, options);
            }

            public async Task<List<Dispute>> GetDisputes()
            {
                try
                {
                    var response = await _supabase
                        .From<Dispute>()
                        .Select("id, booking_id, issue_type, description, status, created_at, created_by_role, resolution_notes, resolved_at, resolved_by, user_id")
                        .Order("created_at", Constants.Ordering.Descending)
                        .Get();

                    return response.Models;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting disputes: {ex.Message}");
                    return new List<Dispute>();
                }
            }

            public async Task<Dispute> GetDispute(Guid id)
            {
                try
                {
                    var filter = new Dictionary<string, string>
                    {
                        { "id", id.ToString() }
                    };

                    var response = await _supabase
                        .From<Dispute>()
                        .Select("id, booking_id, issue_type, description, status, created_at, created_by_role, resolution_notes, resolved_at, resolved_by, user_id")
                        .Match(filter)
                        .Single();
                    
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting dispute: {ex.Message}");
                    return null;
                }
            }

            public async Task<bool> UpdateDisputeStatus(Guid id, string status)
            {
                try
                {
                    var response = await _supabase
                        .From<Dispute>()
                        .Where(x => x.id == id)
                        .Set(x => x.Status, status)
                        .Update();

                    return response != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating dispute status: {ex.Message}");
                    return false;
            }
        }
    }
}