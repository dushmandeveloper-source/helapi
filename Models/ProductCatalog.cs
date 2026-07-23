namespace SpicesTeaHouse;

public record ProductItem(string Name, string Description, string Image);

public record ProductGroup(string? Title, List<ProductItem> Items);

public record ProductCategory(
    string Slug,
    string Name,
    string ShortName,
    string Icon,
    string CardText,
    string Tagline,
    string Image,
    List<ProductGroup> Groups)
{
    public IEnumerable<ProductItem> AllItems => Groups.SelectMany(g => g.Items);
    public int ItemCount => Groups.Sum(g => g.Items.Count);
}

/// <summary>
/// Single source of truth for all product data (Home, Products grid, and details pages).
/// Product names and descriptions are taken verbatim from the Hela Api PDF catalogues.
/// Images are matched per-product and self-hosted under wwwroot/images/products/
/// (originally sourced from Unsplash for category headers and Wikimedia Commons for products).
/// </summary>
public static class ProductCatalog
{
    // ----- Images are self-hosted under wwwroot/images/products/ -----
    private const string Dir = "/images/products/";

    // Category representative images
    private const string ImgTea = Dir + "cat-tea.jpg";
    private const string ImgSpices = Dir + "cat-spices.jpg";
    private const string ImgHerbs = Dir + "cat-herbs.jpg";
    private const string ImgHeritage = Dir + "cat-heritage.jpg";
    private const string ImgRice = Dir + "cat-rice.jpg";
    private const string ImgFruits = Dir + "cat-fruits.jpg";

    // Tea
    private const string ImgBlackTea = Dir + "black-tea.jpg";
    private const string ImgGreenTea = Dir + "green-tea.jpg";
    private const string ImgWhiteTea = Dir + "white-tea.jpg";
    private const string ImgSilverTips = Dir + "silver-tips.jpg";

    // Botanicals / herbs
    private const string ImgMoringa = Dir + "moringa.jpg";
    private const string ImgRanawara = Dir + "ranawara.jpg";
    private const string ImgGotukola = Dir + "gotukola.jpg";
    private const string ImgBelimal = Dir + "belimal.jpg";
    private const string ImgPolpala = Dir + "polpala.jpg";
    private const string ImgIramusu = Dir + "ranawara.jpg";
    private const string ImgKothalaHimbutu = Dir + "gotukola.jpg";
    private const string ImgVenivelgeta = Dir + "moringa.jpg";
    private const string ImgHathawariya = Dir + "polpala.jpg";
    private const string ImgBaelFruit = Dir + "wood-apple.jpg";
    private const string ImgLemongrassTea = Dir + "lemongrass-tea.jpg";
    private const string ImgLemon = Dir + "lemon.jpg";
    private const string ImgMango = Dir + "mango.jpg";
    private const string ImgGinger = Dir + "ginger.jpg";
    private const string ImgPeach = Dir + "peach.jpg";
    private const string ImgVanilla = Dir + "vanilla.jpg";
    private const string ImgMixedFruit = Dir + "mixed-fruit.jpg";
    private const string ImgLemongrass = Dir + "lemongrass.jpg";
    private const string ImgPandan = Dir + "pandan.jpg";
    private const string ImgCurryLeaves = Dir + "curry-leaves.jpg";

    // Spices
    private const string ImgCinnamon = Dir + "cinnamon.jpg";
    private const string ImgPepper = Dir + "black-pepper.jpg";
    private const string ImgWhitePepper = Dir + "white-pepper.jpg";
    private const string ImgCloves = Dir + "cloves.jpg";
    private const string ImgCardamom = Dir + "cardamom.jpg";
    private const string ImgTurmeric = Dir + "turmeric.jpg";
    private const string ImgChilliPowder = Dir + "chilli-powder.jpg";
    private const string ImgChilliFlakes = Dir + "chilli-flakes.jpg";
    private const string ImgMustard = Dir + "mustard.jpg";
    private const string ImgCoriander = Dir + "coriander.jpg";
    private const string ImgCumin = Dir + "cumin.jpg";
    private const string ImgFenugreek = Dir + "fenugreek.jpg";
    private const string ImgGoraka = Dir + "goraka.jpg";
    private const string ImgTamarind = Dir + "tamarind.jpg";
    private const string ImgDriedGinger = Dir + "dried-ginger.png";
    private const string ImgStarAnise = Dir + "star-anise.jpg";
    private const string ImgNutmeg = Dir + "nutmeg.jpg";
    private const string ImgMace = Dir + "mace.jpg";
    private const string ImgFennel = Dir + "fennel.jpg";
    private const string ImgCurryPowder = Dir + "curry-powder.jpg";
    private const string ImgRoastedCurry = Dir + "roasted-curry.jpg";
    private const string ImgUnroastedCurry = Dir + "unroasted-curry.jpg";
    private const string ImgFishCurry = Dir + "fish-curry.jpg";
    private const string ImgChickenCurry = Dir + "chicken-curry.jpg";
    private const string ImgSeafoodCurry = Dir + "seafood-curry.jpg";

    // Heritage
    private const string ImgKithul = Dir + "kithul.jpg";
    private const string ImgJaggery = Dir + "jaggery.jpg";
    private const string ImgSweets = Dir + "sweets.jpg";
    private const string ImgRiceCurry = Dir + "rice-curry.jpg";
    private const string ImgChilliPaste = Dir + "chilli-paste.jpg";
    private const string ImgMalayPickle = Dir + "malay-pickle.jpg";
    private const string ImgDriedFish = Dir + "dried-fish.jpg";
    private const string ImgLimePickle = Dir + "lime-pickle.jpg";
    private const string ImgMangoChutney = Dir + "mango-chutney.jpg";
    private const string ImgBrinjalMoju = Dir + "brinjal-moju.jpg";
    private const string ImgPrawns = Dir + "prawns.jpg";
    private const string ImgAmbulThiyal = Dir + "ambul-thiyal.jpg";

    // Rice & Flour
    private const string ImgRiceBasmati = Dir + "rice-basmati.jpg";
    private const string ImgRiceRed = Dir + "rice-red.jpg";
    private const string ImgRiceBrown = Dir + "rice-brown.jpg";
    private const string ImgRiceTricolor = Dir + "rice-tricolor.jpg";
    private const string ImgRiceCloseup = Dir + "rice-closeup.jpg";
    private const string ImgRiceMushq = Dir + "rice-mushq.jpg";
    private const string ImgRiceFlour = Dir + "rice-flour.jpg";
    private const string ImgRagi = Dir + "ragi.jpg";
    private const string ImgStringHopper = Dir + "string-hopper.jpg";

    // Tropical Fruits
    private const string ImgDriedMango = Dir + "dried-mango.jpg";
    private const string ImgDriedPineapple = Dir + "dried-pineapple.jpg";
    private const string ImgBananaChips = Dir + "banana-chips.jpg";
    private const string ImgNelli = Dir + "nelli.jpg";
    private const string ImgTamarindPulp = Dir + "tamarind-pulp.jpg";
    private const string ImgWoodApple = Dir + "wood-apple.jpg";

    public static readonly List<ProductCategory> Categories = new()
    {
        new("tea", "Hela Ceylon Tea", "Tea", "leaf",
            "Authentic Ceylon tea with natural aroma, strength, and freshness.",
            "Experience the rich taste and heritage of Sri Lanka with our carefully selected premium Ceylon teas, crafted for tea lovers worldwide.",
            ImgTea,
            new()
            {
                new("Ceylon Tea", new()
                {
                    new("Ceylon Black Tea", "Bold, aromatic, and full-bodied with the authentic taste of Sri Lanka.", ImgBlackTea),
                    new("Ceylon Green Tea", "Fresh and delicate with a smooth flavor and natural antioxidants.", ImgGreenTea),
                    new("Ceylon White Tea", "Rare and elegant, offering a light and refined tea experience.", ImgWhiteTea),
                    new("Ceylon Silver Tips", "Handpicked premium tea buds with a naturally sweet and luxurious taste.", ImgSilverTips),
                }),
                new("Herbal Tea", new()
                {
                    new("Moringa Tea", "Nutrient-rich herbal tea made from carefully selected moringa leaves, offering a refreshing taste and natural goodness.", ImgMoringa),
                    new("Ranawara Tea", "Traditional Sri Lankan herbal tea known for its delicate flavor and refreshing character.", ImgRanawara),
                    new("Gotukola Tea", "An ancient herbal infusion appreciated for its fresh taste and long-standing place in Sri Lankan traditions.", ImgGotukola),
                    new("Belimal Tea", "Soothing floral tea made from dried bael flowers, offering a gentle aroma and naturally pleasant flavor.", ImgBelimal),
                    new("Polpala Tea", "Traditional herbal tea enjoyed for its light, refreshing taste and natural wellness appeal.", ImgPolpala),
                    new("Lemongrass Tea", "Refreshing herbal infusion with a bright citrus aroma and a clean, uplifting flavor.", ImgLemongrassTea),
                }),
                new("Flavoured Tea Collection", new()
                {
                    new("Lemon Tea", "Bright and refreshing with a zesty citrus flavor.", ImgLemon),
                    new("Mango Tea", "Sweet tropical notes inspired by juicy Sri Lankan mangoes.", ImgMango),
                    new("Ginger Tea", "Warm and comforting with a naturally spicy kick.", ImgGinger),
                    new("Peach Tea", "Smooth and fruity with a delicate peach aroma.", ImgPeach),
                    new("Vanilla Tea", "Rich and creamy with a soft vanilla sweetness.", ImgVanilla),
                    new("Fruits Blend Tea", "An exciting blend of fruity flavors for a refreshing experience.", ImgMixedFruit),
                }),
            }),

        new("spices", "Hela Spice Collection", "Spices", "flame",
            "100% pure spices with rich aroma and bold flavor.",
            "Discover the rich aromas and authentic flavors of Sri Lanka through our premium selection of spices, herbs, and traditional seasonings, carefully sourced for quality and freshness.",
            ImgSpices,
            new()
            {
                new("Spices & Seasonings", new()
                {
                    new("Ceylon Cinnamon", "Premium Sri Lankan cinnamon renowned for its sweet aroma and delicate flavor.", ImgCinnamon),
                    new("Black Pepper", "Bold and aromatic peppercorns that add warmth and depth to any dish.", ImgPepper),
                    new("White Pepper", "Smooth and earthy pepper with a milder taste and refined aroma.", ImgWhitePepper),
                    new("Cloves", "Intensely fragrant spice with a warm, sweet, and slightly spicy flavor.", ImgCloves),
                    new("Cardamom", "Aromatic spice prized for its unique sweet and citrusy notes.", ImgCardamom),
                    new("Turmeric Powder", "Vibrant golden spice known for its rich flavor and natural goodness.", ImgTurmeric),
                    new("Chilli Powder", "Finely ground chilli that brings heat and color to your cooking.", ImgChilliPowder),
                    new("Chilli Flakes", "Crushed red chillies perfect for adding a spicy kick to meals.", ImgChilliFlakes),
                    new("Mustard Seeds", "Small flavorful seeds commonly used to enhance traditional dishes.", ImgMustard),
                    new("Coriander Seeds", "Fragrant seeds with a mild citrus flavor, ideal for spice blends.", ImgCoriander),
                    new("Cumin Seeds", "Earthy and aromatic seeds that add depth to curries and savory dishes.", ImgCumin),
                    new("Fenugreek Seeds", "Distinctive seeds with a slightly sweet and nutty flavor.", ImgFenugreek),
                    new("Lemongrass", "Refreshing herb with a bright citrus fragrance and taste.", ImgLemongrass),
                    new("Pandan Leaves (Rampe)", "Traditional Sri Lankan aromatic leaves used to enhance flavor and fragrance.", ImgPandan),
                    new("Goraka (Garcinia Cambogia)", "Unique Sri Lankan fruit used to add a tangy and smoky flavor to curries.", ImgGoraka),
                    new("Tamarind", "Naturally tangy fruit that brings a rich sweet-and-sour taste to dishes.", ImgTamarind),
                }),
                new("Additional Popular Spices", new()
                {
                    new("Star Anise", "A beautifully star-shaped spice with a naturally sweet, licorice-like aroma. Commonly used in curries, teas, and spice blends to add warmth and depth.", ImgStarAnise),
                    new("Nutmeg", "A rich, warm spice with a slightly sweet and nutty flavor. Perfect for both sweet and savory dishes, enhancing curries, baked goods, and beverages.", ImgNutmeg),
                    new("Mace", "The delicate outer covering of nutmeg, offering a lighter, more refined flavor. Adds a subtle warmth and aroma to sauces, curries, and spice mixes.", ImgMace),
                    new("Fennel Seeds", "Naturally sweet and refreshing seeds with a light licorice taste. Commonly used after meals and in cooking for aroma and digestion.", ImgFennel),
                    new("Dried Curry Leaves", "Aromatic leaves that bring a signature Sri Lankan flavor. Widely used in tempering, curries, and spice bases for a rich herbal note.", ImgCurryLeaves),
                    new("Dried Ginger pieces", "Naturally dried for lasting flavor, these ginger pieces are both aromatic and versatile. They bring warmth and character to a wide range of dishes.", ImgDriedGinger),
                }),
                new("Sri Lankan Spice Blends", new()
                {
                    new("Curry Powder", "Traditional spice blend crafted to create authentic Sri Lankan curries.", ImgCurryPowder),
                    new("Roasted Curry Powder", "A deeply aromatic blend of roasted spices that delivers a rich, bold flavor. Ideal for traditional Sri Lankan curries with strong taste and color.", ImgRoastedCurry),
                    new("Unroasted Curry Powder", "A fresher, lighter spice blend with vibrant aroma and subtle heat. Perfect for everyday cooking and delicate dishes.", ImgUnroastedCurry),
                    new("Fish Curry Powder", "Specially crafted to enhance seafood dishes with a balanced mix of spice, heat, and tangy aroma. Brings out the natural flavor of fish.", ImgFishCurry),
                    new("Chicken Curry Powder", "A well-balanced blend designed for chicken dishes, offering a rich, savory taste with moderate heat and deep aroma.", ImgChickenCurry),
                    new("Seafood Curry Powder", "A flavorful mix created for seafood dishes, combining spices that enhance prawns, crab, and other seafood with a fragrant, spicy finish.", ImgSeafoodCurry),
                }),
            }),

        new("herbs", "Herbal Powders & Dried Herbs", "Herbs", "sprout",
            "Naturally grown herbs with preserved aroma and nutrients.",
            "Naturally grown herbs, dried botanicals, and powders with preserved aroma and nutrients — rooted in Sri Lanka's traditional knowledge and holistic lifestyle.",
            ImgHerbs,
            new()
            {
                new(null, new()
                {
                    new("Gotu Kola", "A treasured Sri Lankan herb traditionally enjoyed for its refreshing taste and natural wellness benefits.", ImgGotukola),
                    new("Moringa", "Nutrient-rich leaves valued for their versatility and long-standing place in traditional Sri Lankan living.", ImgMoringa),
                    new("Ranawara", "A traditional herbal ingredient commonly enjoyed as a soothing and refreshing herbal infusion.", ImgRanawara),
                    new("Bel Leaves", "Naturally aromatic leaves traditionally brewed into a refreshing herbal beverage.", ImgBelimal),
                    new("Iramusu", "A fragrant root traditionally used to prepare cooling and refreshing herbal drinks.", ImgIramusu),
                    new("Polpala", "A cherished Sri Lankan herb widely enjoyed as a light and refreshing herbal tea.", ImgPolpala),
                    new("Kothala Himbutu", "A traditional forest herb valued for its place in Sri Lankan herbal traditions.", ImgKothalaHimbutu),
                    new("Venivelgeta", "A distinctive herb traditionally used in herbal preparations and wellness beverages.", ImgVenivelgeta),
                    new("Hathawariya", "A respected traditional herb appreciated for its long history in Sri Lankan wellness practices.", ImgHathawariya),
                    new("Nelli (Indian Gooseberry)", "A naturally tangy fruit celebrated for its refreshing flavor and nutritional value.", ImgNelli),
                    new("Bael Fruit (Beli)", "A naturally sweet fruit traditionally enjoyed in refreshing beverages and herbal preparations.", ImgBaelFruit),
                }),
            }),

        new("heritage", "Hela Heritage Collection", "Heritage", "landmark",
            "Authentic Sri Lankan cultural products.",
            "Celebrate the rich culinary traditions of Sri Lanka with our collection of authentic heritage foods, traditional sweets, and ready-to-enjoy delicacies crafted from generations of local recipes.",
            ImgHeritage,
            new()
            {
                new("Traditional Foods & Sweets", new()
                {
                    new("Kithul Products", "Traditional products made from the natural sweetness of Sri Lanka's treasured Kithul palm.", ImgKithul),
                    new("Coconut Jaggery (Pol Hakuru)", "Traditional coconut jaggery with a rich caramel-like sweetness, perfect for authentic Sri Lankan treats.", ImgJaggery),
                    new("Traditional Sweets", "Authentic Sri Lankan sweets crafted from time-honored recipes and natural ingredients.", ImgSweets),
                    new("Sri Lankan Ready-to-Eat Foods", "Convenient traditional Sri Lankan meals prepared with authentic flavors and spices.", ImgRiceCurry),
                }),
                new("Sambols & Pickles", new()
                {
                    new("Chilli Paste", "Rich and spicy paste made from selected chillies for an authentic Sri Lankan flavor.", ImgChilliPaste),
                    new("Malay Pickle (Malay Achcharu)", "A sweet, spicy, and tangy mixed pickle inspired by Sri Lanka's Malay heritage.", ImgMalayPickle),
                    new("Sprat Sambol (Haalmasso Sambol)", "Traditional sambol made with dried sprats and aromatic spices.", ImgDriedFish),
                    new("Lunu Dehi", "Preserved lime pickle bursting with bold, tangy, and savory flavors.", ImgLimePickle),
                    new("Mango Chutney", "Sweet and tangy mango relish that complements a variety of dishes.", ImgMangoChutney),
                    new("Wambatu Moju", "Traditional sweet and sour eggplant pickle with rich Sri Lankan spices.", ImgBrinjalMoju),
                    new("Prawn Badum (Isso Badum)", "Crispy seasoned prawns prepared with authentic Sri Lankan flavors.", ImgPrawns),
                    new("Fish Ambul Thiyal", "Traditional sour fish curry known for its distinctive tangy taste and long-lasting freshness.", ImgAmbulThiyal),
                    new("Hela Achcharu", "A traditional Sri Lankan mixed vegetable pickle crafted with fresh ingredients and authentic local spices. Bursting with sweet, tangy, and spicy flavors, it brings the true taste of Sri Lankan heritage to every meal.", ImgMalayPickle),
                }),
            }),

        new("rice-flour", "Hela Traditional Rice & Flour", "Rice & Flour", "wheat",
            "Premium grains with purity and consistent cooking quality.",
            "Discover Sri Lanka's heritage grains and traditional flours, carefully selected for their authentic taste, nutritional value, and cultural significance.",
            ImgRice,
            new()
            {
                new("Heritage Rice", new()
                {
                    new("Suwandel Rice", "A fragrant heritage rice variety prized for its delicate aroma and soft texture.", ImgRiceBasmati),
                    new("Kalu Heenati Rice", "A traditional Sri Lankan red rice known for its rich flavor and distinctive character.", ImgRiceRed),
                    new("Maa Wee Rice", "An ancient rice variety cherished for its wholesome taste and traditional heritage.", ImgRiceBrown),
                    new("Pachchaperumal Rice", "A nutritious heirloom red rice celebrated for its unique color and rich flavor.", ImgRiceTricolor),
                    new("Kuruluthuda Rice", "A traditional Sri Lankan rice variety valued for its distinctive taste and authenticity.", ImgRiceCloseup),
                    new("Water Lily Rice", "A unique Sri Lankan grain inspired by traditional cultivation practices and natural goodness.", ImgRiceMushq),
                }),
                new("Traditional Flours", new()
                {
                    new("Rice Flour", "Finely milled flour ideal for traditional Sri Lankan cooking and desserts.", ImgRiceFlour),
                    new("Kurakkan Flour", "Nutritious finger millet flour widely used in authentic Sri Lankan recipes.", ImgRagi),
                    new("Roasted Rice Flour", "A traditional flour essential for many Sri Lankan sweets and snacks.", ImgRiceFlour),
                    new("String Hopper Flour", "Specially prepared flour for making soft and delicious string hoppers.", ImgStringHopper),
                }),
            }),

        new("tropical-fruits", "Hela Tropical Fruits", "Tropical Fruits", "cherry",
            "Naturally dried fruits with natural sweetness and flavor.",
            "Discover the naturally sweet flavors of Sri Lanka through our selection of carefully dried tropical fruits and fruit-based products.",
            ImgFruits,
            new()
            {
                new(null, new()
                {
                    new("Dried Mango", "Naturally sweet tropical mango slices.", ImgDriedMango),
                    new("Dried Pineapple", "Delicious pineapple with a perfect balance of sweetness and tanginess.", ImgDriedPineapple),
                    new("Dried Banana", "Crispy and naturally sweet banana snacks.", ImgBananaChips),
                    new("Dried Nelli (Indian Gooseberry)", "Tangy fruit rich in natural goodness.", ImgNelli),
                    new("Dried Tamarind", "Traditional tropical fruit with a sweet and sour flavor.", ImgTamarindPulp),
                    new("Dried Wood Apple", "Unique Sri Lankan fruit known for its distinctive taste.", ImgWoodApple),
                }),
            }),
    };

    public static ProductCategory? BySlug(string? slug) =>
        Categories.FirstOrDefault(c => c.Slug == (slug ?? "").ToLowerInvariant());
}
