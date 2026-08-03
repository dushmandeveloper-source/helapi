// Self-hosted replacement for window.lucide.createIcons() — renders icons from window.__icons
// (populated by icons.js) with no external network dependency.
window.lucide = {
    createIcons: function () {
        var icons = window.__icons || {};
        document.querySelectorAll('i[data-lucide]').forEach(function (el) {
            var name = el.getAttribute('data-lucide');
            var inner = icons[name];
            if (!inner) return;

            var width = el.getAttribute('width') || '24';
            var height = el.getAttribute('height') || '24';
            var extraClass = el.getAttribute('class') || '';

            var svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
            svg.setAttribute('xmlns', 'http://www.w3.org/2000/svg');
            svg.setAttribute('width', width);
            svg.setAttribute('height', height);
            svg.setAttribute('viewBox', '0 0 24 24');
            svg.setAttribute('fill', 'none');
            svg.setAttribute('stroke', 'currentColor');
            svg.setAttribute('stroke-width', '2');
            svg.setAttribute('stroke-linecap', 'round');
            svg.setAttribute('stroke-linejoin', 'round');
            if (extraClass) svg.setAttribute('class', extraClass);
            svg.innerHTML = inner;

            el.replaceWith(svg);
        });
    }
};
