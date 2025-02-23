document.addEventListener('DOMContentLoaded', function() {
    window.addEventListener('scroll', function() {
        const heroSection = document.querySelector('.hero-section');
        const featuresSection = document.querySelector('.features-section');
        const scrollPosition = window.scrollY;
        const heroBottom = heroSection.offsetTop + heroSection.offsetHeight;
        
        if (scrollPosition > heroSection.offsetTop && scrollPosition < heroBottom) {
            const progress = ((scrollPosition - heroSection.offsetTop) / heroSection.offsetHeight) *2;
            const startColor = { r: 118, g: 168, b: 148 }; // #76a894
            const endColor = { r: 255, g: 255, b: 255 }; // #FFFFFF
            
            const currentColor = {
                r: Math.round(startColor.r + (endColor.r - startColor.r) * progress),
                g: Math.round(startColor.g + (endColor.g - startColor.g) * progress),
                b: Math.round(startColor.b + (endColor.b - startColor.b) * progress)
            };
            
            featuresSection.style.backgroundColor = 
                `rgb(${currentColor.r}, ${currentColor.g}, ${currentColor.b})`;
        }
    });

    const sections = document.querySelectorAll('.how-it-works-section');
    const points = document.querySelectorAll('.point');
    const progressFill = document.querySelector('.progress-fill');
    const title = document.querySelector('.section-title');
    const progressBar = document.querySelector('.progress-bar');
    const howItWorksSection = document.querySelector('.how-it-works');
    
    function updateSection() {
        const scrollPosition = window.scrollY;
        const howItWorks = document.querySelector('.how-it-works');
        const sectionHeight = window.innerHeight;
        const startOffset = howItWorks.offsetTop;
        
        const progress = (scrollPosition - startOffset) / (sectionHeight * 4);
        progressFill.style.height = `${Math.min(100, progress * 100)}%`;
        
        const currentSection = Math.floor(progress * 4);
        
        title.classList.toggle('active', currentSection === 0);
        
        sections.forEach((section, index) => {
            section.classList.toggle('active', index === currentSection);
        });
        
        points.forEach((point, index) => {
            point.classList.toggle('active', index <= currentSection);
        });
    }
    
    window.addEventListener('scroll', function() {
        const rect = howItWorksSection.getBoundingClientRect();
        const progress = Math.abs(rect.top) / (rect.height - window.innerHeight);
        
        // Show progress bar only when in How It Works section and not complete
        const isInView = rect.top <= 0 && progress < 1;
        
        progressBar.classList.toggle('visible', isInView);
        
        if (isInView) {
            const progressFill = document.querySelector('.progress-fill');
            progressFill.style.height = `${Math.min(100, progress * 100)}%`;
            
            const currentSection = Math.min(3, Math.floor(progress * 4));
            points.forEach((point, index) => {
                point.classList.toggle('active', index <= currentSection);
            });
        }
    });
    
    window.addEventListener('scroll', updateSection);
    updateSection();
});