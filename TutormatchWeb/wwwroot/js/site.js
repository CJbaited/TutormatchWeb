document.addEventListener('DOMContentLoaded', function() {
    window.addEventListener('scroll', function() {
        const heroSection = document.querySelector('.hero-section');
        const featuresSection = document.querySelector('.features-section');
        const scrollPosition = window.scrollY;
        const heroBottom = heroSection.offsetTop + heroSection.offsetHeight;
        
        if (scrollPosition > heroSection.offsetTop && scrollPosition < heroBottom) {
            const progress = ((scrollPosition - heroSection.offsetTop) / heroSection.offsetHeight) *2;
            const startColor = { r: 9, g: 98, b: 91 }; // #084843
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
});