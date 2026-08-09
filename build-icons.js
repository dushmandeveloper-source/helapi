const fs = require('fs');
const path = require('path');

const icons = [
  'arrow-left', 'arrow-right', 'badge-check', 'book-open', 'check-circle',
  'cherry', 'chevron-right', 'clock', 'coffee', 'eye', 'facebook', 'flame',
  'gift', 'globe', 'hand', 'instagram', 'landmark', 'leaf', 'mail', 'map-pin',
  'menu', 'package-x', 'palette', 'phone', 'scroll-text', 'send', 'settings',
  'shield-check', 'shirt', 'sparkles', 'sprout', 'star', 'sun', 'target',
  'trophy', 'utensils', 'wheat', 'x'
];

const iconsDir = path.join(__dirname, 'node_modules', 'lucide-static', 'icons');
const result = {};

// Some data-lucide names used in the markup were renamed upstream in newer lucide-static releases.
const renames = { 'check-circle': 'circle-check' };

for (const name of icons) {
  const sourceName = renames[name] || name;
  const file = path.join(iconsDir, `${sourceName}.svg`);
  if (!fs.existsSync(file)) {
    console.error(`MISSING ICON: ${name}`);
    continue;
  }
  const svg = fs.readFileSync(file, 'utf8');
  const inner = svg
    .replace(/<!--.*?-->/s, '')
    .match(/<svg[^>]*>([\s\S]*)<\/svg>/)[1]
    .trim();
  result[name] = inner;
}

// lucide-static dropped brand icons; keep these two as fixed paths (from lucide-static <1.24).
result['facebook'] = '<path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" />';
result['instagram'] = '<rect width="20" height="20" x="2" y="2" rx="5" ry="5" /><path d="M16 11.37A4 4 0 1 1 12.63 8 4 4 0 0 1 16 11.37z" /><line x1="17.5" x2="17.51" y1="6.5" y2="6.5" />';

const out = `// Self-hosted icon set (generated from lucide-static, no CDN dependency).
// Regenerate with: node build-icons.js
window.__icons = ${JSON.stringify(result, null, 2)};
`;

fs.writeFileSync(path.join(__dirname, 'wwwroot', 'icons.js'), out);
console.log(`Wrote ${Object.keys(result).length} icons to wwwroot/icons.js`);
