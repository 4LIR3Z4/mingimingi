using IdGen;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Domain.Framework;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.Prompts.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.AcceptanceTests.Utilities;
internal class MockReferenceDataCache : IReferenceDataCache
{
    public Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        List<Country> countryList = new List<Country>();
        var usa = Country.Create("United States", "US");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(usa, 1, null);
        countryList.Add(usa);
        var unitedKingdom = Country.Create("United Kingdom", "GB");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(unitedKingdom, 2, null);
        countryList.Add(unitedKingdom);

        var canada = Country.Create("Canada", "CA");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(canada, 3, null);
        countryList.Add(canada);

        var australia = Country.Create("Australia", "AU");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(australia, 4, null);
        countryList.Add(australia);

        var germany = Country.Create("Germany", "DE");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(germany, 5, null);
        countryList.Add(germany);

        var france = Country.Create("France", "FR");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(france, 6, null);
        countryList.Add(france);

        var spain = Country.Create("Spain", "ES");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(spain, 7, null);
        countryList.Add(spain);

        var italy = Country.Create("Italy", "IT");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(italy, 8, null);
        countryList.Add(italy);

        var japan = Country.Create("Japan", "JP");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(japan, 9, null);
        countryList.Add(japan);

        var china = Country.Create("China", "CN");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(china, 10, null);
        countryList.Add(china);

        var india = Country.Create("India", "IN");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(india, 11, null);
        countryList.Add(india);

        var brazil = Country.Create("Brazil", "BR");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(brazil, 12, null);
        countryList.Add(brazil);

        var mexico = Country.Create("Mexico", "MX");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(mexico, 13, null);
        countryList.Add(mexico);

        var southAfrica = Country.Create("South Africa", "ZA");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(southAfrica, 14, null);
        countryList.Add(southAfrica);
        return Task.FromResult(countryList);
    }

    public Task<List<Hobby>> GetHobbiesAsync(CancellationToken cancellationToken)
    {
        List<Hobby> hobbies = new List<Hobby>();
        var reading = Hobby.Create("Reading");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(reading, 1, null);
        hobbies.Add(reading);

        var traveling = Hobby.Create("Traveling");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(traveling, 2, null);
        hobbies.Add(traveling);

        var cooking = Hobby.Create("Cooking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(cooking, 3, null);
        hobbies.Add(cooking);

        var photography = Hobby.Create("Photography");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(photography, 4, null);
        hobbies.Add(photography);

        var gardening = Hobby.Create("Gardening");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(gardening, 5, null);
        hobbies.Add(gardening);

        var painting = Hobby.Create("Painting");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(painting, 6, null);
        hobbies.Add(painting);

        var music = Hobby.Create("Music");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(music, 7, null);
        hobbies.Add(music);

        var sports = Hobby.Create("Sports");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(sports, 8, null);
        hobbies.Add(sports);

        var writing = Hobby.Create("Writing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(writing, 9, null);
        hobbies.Add(writing);

        var dancing = Hobby.Create("Dancing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(dancing, 10, null);
        hobbies.Add(dancing);

        var gaming = Hobby.Create("Gaming");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(gaming, 11, null);
        hobbies.Add(gaming);

        var crafting = Hobby.Create("Crafting");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(crafting, 12, null);
        hobbies.Add(crafting);

        var fishing = Hobby.Create("Fishing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(fishing, 13, null);
        hobbies.Add(fishing);

        var hiking = Hobby.Create("Hiking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(hiking, 14, null);
        hobbies.Add(hiking);

        var cycling = Hobby.Create("Cycling");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(cycling, 15, null);
        hobbies.Add(cycling);

        var swimming = Hobby.Create("Swimming");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(swimming, 16, null);
        hobbies.Add(swimming);

        var yoga = Hobby.Create("Yoga");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(yoga, 17, null);
        hobbies.Add(yoga);

        var knitting = Hobby.Create("Knitting");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(knitting, 18, null);
        hobbies.Add(knitting);

        var sewing = Hobby.Create("Sewing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(sewing, 19, null);
        hobbies.Add(sewing);

        var woodworking = Hobby.Create("Woodworking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(woodworking, 20, null);
        hobbies.Add(woodworking);

        var metalworking = Hobby.Create("Metalworking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(metalworking, 21, null);
        hobbies.Add(metalworking);

        var pottery = Hobby.Create("Pottery");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(pottery, 22, null);
        hobbies.Add(pottery);

        var baking = Hobby.Create("Baking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(baking, 23, null);
        hobbies.Add(baking);

        var calligraphy = Hobby.Create("Calligraphy");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(calligraphy, 24, null);
        hobbies.Add(calligraphy);

        var origami = Hobby.Create("Origami");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(origami, 25, null);
        hobbies.Add(origami);

        var scrapbooking = Hobby.Create("Scrapbooking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(scrapbooking, 26, null);
        hobbies.Add(scrapbooking);

        var modelBuilding = Hobby.Create("Model Building");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(modelBuilding, 27, null);
        hobbies.Add(modelBuilding);

        var collecting = Hobby.Create("Collecting");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(collecting, 28, null);
        hobbies.Add(collecting);

        var birdwatching = Hobby.Create("Birdwatching");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(birdwatching, 29, null);
        hobbies.Add(birdwatching);

        var astronomy = Hobby.Create("Astronomy");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(astronomy, 30, null);
        hobbies.Add(astronomy);

        var martialArts = Hobby.Create("Martial Arts");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(martialArts, 31, null);
        hobbies.Add(martialArts);

        var meditation = Hobby.Create("Meditation");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(meditation, 32, null);
        hobbies.Add(meditation);

        var volunteering = Hobby.Create("Volunteering");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(volunteering, 33, null);
        hobbies.Add(volunteering);

        var learning = Hobby.Create("Learning");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(learning, 34, null);
        hobbies.Add(learning);

        var coding = Hobby.Create("Coding");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(coding, 35, null);
        hobbies.Add(coding);

        var blogging = Hobby.Create("Blogging");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(blogging, 36, null);
        hobbies.Add(blogging);

        var podcasting = Hobby.Create("Podcasting");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(podcasting, 37, null);
        hobbies.Add(podcasting);

        var vlogging = Hobby.Create("Vlogging");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(vlogging, 38, null);
        hobbies.Add(vlogging);

        var standUpComedy = Hobby.Create("Stand-up Comedy");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(standUpComedy, 39, null);
        hobbies.Add(standUpComedy);

        var magic = Hobby.Create("Magic");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(magic, 40, null);
        hobbies.Add(magic);

        var boardGames = Hobby.Create("Board Games");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(boardGames, 41, null);
        hobbies.Add(boardGames);

        var cardGames = Hobby.Create("Card Games");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(cardGames, 42, null);
        hobbies.Add(cardGames);

        var puzzles = Hobby.Create("Puzzles");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(puzzles, 43, null);
        hobbies.Add(puzzles);

        var chess = Hobby.Create("Chess");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(chess, 44, null);
        hobbies.Add(chess);

        var rolePlayingGames = Hobby.Create("Role-playing Games");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(rolePlayingGames, 45, null);
        hobbies.Add(rolePlayingGames);

        var escapeRooms = Hobby.Create("Escape Rooms");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(escapeRooms, 46, null);
        hobbies.Add(escapeRooms);

        var virtualReality = Hobby.Create("Virtual Reality");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(virtualReality, 47, null);
        hobbies.Add(virtualReality);

        var augmentedReality = Hobby.Create("Augmented Reality");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(augmentedReality, 48, null);
        hobbies.Add(augmentedReality);

        var threeDPrinting = Hobby.Create("3D Printing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(threeDPrinting, 49, null);
        hobbies.Add(threeDPrinting);

        var droneFlying = Hobby.Create("Drone Flying");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(droneFlying, 50, null);
        hobbies.Add(droneFlying);

        var robotics = Hobby.Create("Robotics");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(robotics, 51, null);
        hobbies.Add(robotics);

        var electronics = Hobby.Create("Electronics");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(electronics, 52, null);
        hobbies.Add(electronics);
        return Task.FromResult(hobbies);
    }

    public Task<List<Interest>> GetInterestsAsync(CancellationToken cancellationToken)
    {
        List<Interest> interests = new List<Interest>();
        var technology = Interest.Create("Technology");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(technology, 1, null);
        interests.Add(technology);

        var science = Interest.Create("Science");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(science, 2, null);
        interests.Add(science);

        var art = Interest.Create("Art");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(art, 3, null);
        interests.Add(art);

        var history = Interest.Create("History");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(history, 4, null);
        interests.Add(history);

        var music = Interest.Create("Music");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(music, 5, null);
        interests.Add(music);

        var sports = Interest.Create("Sports");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(sports, 6, null);
        interests.Add(sports);

        var travel = Interest.Create("Travel");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(travel, 7, null);
        interests.Add(travel);

        var food = Interest.Create("Food");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(food, 8, null);
        interests.Add(food);

        var nature = Interest.Create("Nature");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(nature, 9, null);
        interests.Add(nature);

        var fitness = Interest.Create("Fitness");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(fitness, 10, null);
        interests.Add(fitness);

        var fashion = Interest.Create("Fashion");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(fashion, 11, null);
        interests.Add(fashion);

        var photography = Interest.Create("Photography");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(photography, 12, null);
        interests.Add(photography);

        var writing = Interest.Create("Writing");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(writing, 13, null);
        interests.Add(writing);

        var gaming = Interest.Create("Gaming");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(gaming, 14, null);
        interests.Add(gaming);

        var movies = Interest.Create("Movies");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(movies, 15, null);
        interests.Add(movies);

        var television = Interest.Create("Television");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(television, 16, null);
        interests.Add(television);

        var theater = Interest.Create("Theater");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(theater, 17, null);
        interests.Add(theater);

        var dance = Interest.Create("Dance");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(dance, 18, null);
        interests.Add(dance);

        var cooking = Interest.Create("Cooking");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(cooking, 19, null);
        interests.Add(cooking);

        var gardening = Interest.Create("Gardening");
        typeof(BaseEntity<int>).GetProperty("Id")?.SetValue(gardening, 20, null);
        interests.Add(gardening);
        return Task.FromResult(interests);
    }

    public Task<List<Language>> GetLanguagesAsync(CancellationToken cancellationToken)
    {
        List<Language> languages = new List<Language>();
        languages.Add(Language.Create(1, "En", "English"));
        languages.Add(Language.Create(2, "Fr", "French"));
        languages.Add(Language.Create(3, "Es", "Spanish"));
        languages.Add(Language.Create(4, "De", "German"));
        languages.Add(Language.Create(5, "It", "Italian"));
        languages.Add(Language.Create(6, "Pt", "Portuguese"));
        languages.Add(Language.Create(7, "Ru", "Russian"));
        languages.Add(Language.Create(8, "Zh", "Chinese"));
        languages.Add(Language.Create(9, "Ja", "Japanese"));
        languages.Add(Language.Create(10, "Ko", "Korean"));
        languages.Add(Language.Create(11, "Ar", "Arabic"));
        languages.Add(Language.Create(12, "Hi", "Hindi"));
        languages.Add(Language.Create(13, "Fa", "Persian"));
        return Task.FromResult(languages);

    }

    public Task<List<Prompt>> GetPromptsAsync(CancellationToken cancellationToken)
    {
        List<Prompt> prompts = new List<Prompt>();
        prompts.Add(Prompt.Create("Introduction", "1.0", "Tell me about yourself.", "A simple introduction prompt.", new Dictionary<string, string>()));
        prompts.Add(Prompt.Create("Daily Routine", "1.0", "Describe your daily routine.", "A prompt to discuss daily activities.", new Dictionary<string, string>()));
        return Task.FromResult(prompts);
    }
}
