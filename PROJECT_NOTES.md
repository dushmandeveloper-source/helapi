# Hela Api Tea House — Blazor Conversion Notes

## Overview
React (App.tsx) landing page ported to Blazor Web App (.NET 10, Interactive Server).

## Stack
- Tailwind CSS (CDN) + custom font config (Inter, Playfair Display)
- lucide icons (CDN UMD) via `<i data-lucide="...">` + `lucide.createIcons()`
- GSAP (CDN) for hero text animations
- animate.css (CDN) for mobile menu transitions
- Bootstrap removed (unused, was scaffold default)

## Key Files
- `Components/Pages/Home.razor` — full page (top bar, nav, hero carousel, features, categories, best sellers slider, why-choose-us, footer)
- `Components/App.razor` — CDN script/style includes (tailwind, lucide, gsap, animate.css, fonts)
- `wwwroot/site.js` — JS interop helpers: `init` (resize listener), `createIcons`, `animateHero`, `getItemsPerView`

## Architecture Notes
- Carousels (hero auto-advance 6s, products auto-advance 4s) use `System.Threading.Timer` + `InvokeAsync(StateHasChanged)`
- Responsive `itemsPerView` (2/3/4 cols) synced via `DotNetObjectReference` + `[JSInvokable] OnResize`
- `IDisposable` cleans up timers + JS object ref

## Critical Fix
`Home.razor` needed `@rendermode InteractiveServer` — without it the page was static-only:
no SignalR connection → no JS interop, no icons/animations, no click handlers.

## Run
```powershell
cd "E:\Adeesha Project\Spices Blasor project\SpicesTeaHouse"
dotnet run
```
Open the printed `http://localhost:....` URL.

## Status
Build: 0 errors. App runs and renders correctly with icons, GSAP animations, and carousels working.

## Permissions
Build/run dotnet commands without asking for confirmation each time.

## Build Note
If `dotnet build` fails with "file locked / process cannot access .exe", a previous
`dotnet run` instance is still active. Stop it first:
```powershell
Get-Process -Name SpicesTeaHouse -ErrorAction SilentlyContinue | Stop-Process -Force
```

## Changelog
- Features Bar: 2-column grid on mobile (stacked icon+text, centered), 4-column row from `sm:` up.
- Switched theme to "light organic marketplace" palette + fonts:
  - Cream `#FFF9F0` (page/section bg), Light Sage `#DDE8C8` (section bg)
  - Main Green `#5E8C31`, Deep Green `#3F5F22` (nav/footer/logo bands)
  - Gold `#D4A437`, Cinnamon Brown `#B97A4A` (accents)
  - Fonts: Cormorant Garamond (headings/serif), Poppins (body/sans)
- Hero banner overlay lightened: `from-black/90 via-black/50` -> `from-black/50 via-black/25`
- Removed shopping cart UI: cart icons + badges from desktop/mobile nav, and "add to cart" button from product cards.
- Top bar text color changed from `text-gray-300` to `text-white` for better contrast against the dark green background.
- Extracted shared header (top bar + nav + mobile menu) and footer into reusable components: `Components/Shared/SiteHeader.razor` and `Components/Shared/SiteFooter.razor`. Added `@using SpicesTeaHouse.Components.Shared` to `_Imports.razor`. `Home.razor` now uses `<SiteHeader />` / `<SiteFooter />`.
- Added new About page (`Components/Pages/About.razor`, route `/about`), converted from React, using the shared header/footer, "About Hela Api" hero, brand positioning, products & services portfolio, and core values grid (with float/pan-bg CSS animations).
- Nav links (HOME/ABOUT) now highlight active page based on current route.
- About page hero banner image darkened: opacity `40` -> `70`.
- About page hero text colors changed to white for visibility against banner image: "Our Story" and "About Hela Api".
- Removed first hero slide on Home page (broken/non-loading image), now 2 hero slides remain.
- Fixed broken images (404s) across Home page, verified each URL returns HTTP 200:
  - "Teas" category card image -> Unsplash photo-1597318181409-cf64d0b5d8a2
  - Ceylon White Tea -> Wikimedia "Glass_of_Chinese_Baicha.jpg"
  - Ceylon Cinnamon -> Wikimedia "Cinnamomum_verum_spices.jpg"
  - Pure Black Pepper -> Wikimedia "Black_Peppercorns_(4422070187).jpg"
  - Traditional Pol Sambol -> Wikimedia "Coconut_Chutney_-_Home_Made.JPG"
  - Whole Cardamom -> Wikimedia "Cardamom_pods_-_Green_BNC.jpg"
  - Premium Cloves -> Wikimedia "2023_Goździki.jpg"
- "Teas" category card overlay: replaced strong green tint (`bg-[#5E8C31] mix-blend-multiply opacity-90`) with a subtle dark overlay (`bg-black/30`) so the tea image shows through clearly.
- Removed search and user/login icons from desktop nav (SiteHeader).
- Removed "PAGES" nav link from desktop and mobile menus (SiteHeader).
- Footer (SiteFooter) text colors changed from gray shades to white throughout.
- Added new Products page (`Components/Pages/Products.razor`, route `/products`), using shared header/footer:
  - Page header banner with "Our Collection / Products" title.
  - Category dropdown filter (All Categories, Tea, Spices, Foods) bound to a `selectedCategory` field, filters the product grid live.
  - Extended product list to 10 items (added "Ceylon Silver Tips Tea" and "Sri Lankan Chicken Curry Mix") tagged with categories, each with a category badge on the card.
  - Product grid reuses the card design from Home's Best Sellers (image, star ratings, price in `#5E8C31`).
  - Updated SiteHeader "PRODUCTS" nav link (desktop + mobile) and SiteFooter "Products" quick link to point to `/products`, with active-link highlighting.
- Products page banner updated to match the About page hero style: same background image with `pan-bg` animation, dark overlay, and white "Our Collection" / "Products" text.
- Removed "Traditional Pol Sambol" and "Sri Lankan Chicken Curry Mix" products from Home page Best Sellers and Products page (Foods category removed from Products dropdown since no items remain).
- Replaced product images:
  - "Pure Black Pepper" -> Unsplash premium photo of a wooden spoon with black/red seeds (`premium_photo-1668447605666-716a18e15a1d`)
  - "Ceylon White Tea" -> Unsplash premium photo (`premium_photo-1730985575682-ce2e30aa19b4`)
- Home page hero "Shop Now" and "Explore More" buttons now link to `/products`.
- Removed "STORE" link from header (desktop + mobile nav) and footer quick links.
- Header logo text changed from "TEA House" to "Hela Api".
- Product card images (Home Best Sellers + Products page) now fill the entire image area using `object-cover` (instead of small `object-contain` with `mix-blend-multiply`), giving fuller, more vibrant product photos.
- Added new Contact Us page (`Components/Pages/Contact.razor`, route `/contact`), using shared header/footer:
  - Hero banner matching About/Products style (pan-bg image, dark overlay, white "We'd Love To Hear From You" / "Contact Us" text).
  - Contact info cards (Address, Call Us, Email Us).
  - Contact form (name, email, subject, message) with validation submit, success message on send.
  - Embedded Google Maps location + "Visit Our Store" info panel.
  - Updated SiteHeader "CONTACT" nav link (desktop + mobile, with active highlighting) and SiteFooter "Contact" quick link to point to `/contact`.
