window.siteInterop = {
    dotNetRef: null,

    getItemsPerView: function () {
        const w = window.innerWidth;
        if (w < 640) return 2;
        if (w < 1024) return 3;
        return 4;
    },

    init: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
        window.addEventListener('resize', () => {
            if (this.dotNetRef) {
                this.dotNetRef.invokeMethodAsync('OnResize', window.innerWidth);
            }
        });
    },

    createIcons: function () {
        if (window.lucide) {
            window.lucide.createIcons();
        }
    },

    animateHero: function () {
        if (window.gsap) {
            window.gsap.fromTo('.anim-title',
                { y: 50, opacity: 0 },
                { y: 0, opacity: 1, duration: 1, stagger: 0.15, ease: "power3.out", overwrite: true }
            );
            window.gsap.fromTo('.anim-fade',
                { opacity: 0, scale: 0.95 },
                { opacity: 1, scale: 1, duration: 1.5, delay: 0.3, ease: "power2.out", overwrite: true }
            );
        }
    }
};
