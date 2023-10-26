// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Lib.Ansi;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class AnsiColors { 
    private static readonly Dictionary<string, ByteVector3> _colorDictionary = new();
    public static ReadOnlyDictionary<string, ByteVector3> knownColorsDictionary => _colorDictionary.AsReadOnly();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    static AnsiColors() {
        _colorDictionary.Add("maroon",                  new ByteVector3(128,0,0));
        _colorDictionary.Add("darkred",                 new ByteVector3(139,0,0));
        _colorDictionary.Add("brown",                   new ByteVector3(165,42,42));
        _colorDictionary.Add("firebrick",               new ByteVector3(178,34,34));
        _colorDictionary.Add("crimson",                 new ByteVector3(220,20,60));
        _colorDictionary.Add("red",                     new ByteVector3(255,0,0));
        _colorDictionary.Add("tomato",                  new ByteVector3(255,99,71));
        _colorDictionary.Add("coral",                   new ByteVector3(255,127,80));
        _colorDictionary.Add("indianred",               new ByteVector3(205,92,92));
        _colorDictionary.Add("lightcoral",              new ByteVector3(240,128,128));
        _colorDictionary.Add("darksalmon",              new ByteVector3(233,150,122));
        _colorDictionary.Add("salmon",                  new ByteVector3(250,128,114));
        _colorDictionary.Add("lightsalmon",             new ByteVector3(255,160,122));
        _colorDictionary.Add("orangered",               new ByteVector3(255,69,0));
        _colorDictionary.Add("darkorange",              new ByteVector3(255,140,0));
        _colorDictionary.Add("orange",                  new ByteVector3(255,165,0));
        _colorDictionary.Add("gold",                    new ByteVector3(255,215,0));
        _colorDictionary.Add("darkgoldenrod",           new ByteVector3(184,134,11));
        _colorDictionary.Add("goldenrod",               new ByteVector3(218,165,32));
        _colorDictionary.Add("palegoldenrod",           new ByteVector3(238,232,170));
        _colorDictionary.Add("darkkhaki",               new ByteVector3(189,183,107));
        _colorDictionary.Add("khaki",                   new ByteVector3(240,230,140));
        _colorDictionary.Add("olive",                   new ByteVector3(128,128,0));
        _colorDictionary.Add("yellow",                  new ByteVector3(255,255,0));
        _colorDictionary.Add("yellowgreen",             new ByteVector3(154,205,50));
        _colorDictionary.Add("darkolivegreen",          new ByteVector3(85,107,47));
        _colorDictionary.Add("olivedrab",               new ByteVector3(107,142,35));
        _colorDictionary.Add("lawngreen",               new ByteVector3(124,252,0));
        _colorDictionary.Add("chartreuse",              new ByteVector3(127,255,0));
        _colorDictionary.Add("greenyellow",             new ByteVector3(173,255,47));
        _colorDictionary.Add("darkgreen",               new ByteVector3(0,100,0));
        _colorDictionary.Add("green",                   new ByteVector3(0,128,0));
        _colorDictionary.Add("forestgreen",             new ByteVector3(34,139,34));
        _colorDictionary.Add("lime",                    new ByteVector3(0,255,0));
        _colorDictionary.Add("limegreen",               new ByteVector3(50,205,50));
        _colorDictionary.Add("lightgreen",              new ByteVector3(144,238,144));
        _colorDictionary.Add("palegreen",               new ByteVector3(152,251,152));
        _colorDictionary.Add("darkseagreen",            new ByteVector3(143,188,143));
        _colorDictionary.Add("mediumspringgreen",       new ByteVector3(0,250,154));
        _colorDictionary.Add("springgreen",             new ByteVector3(0,255,127));
        _colorDictionary.Add("seagreen",                new ByteVector3(46,139,87));
        _colorDictionary.Add("mediumaquamarine",        new ByteVector3(102,205,170));
        _colorDictionary.Add("mediumseagreen",          new ByteVector3(60,179,113));
        _colorDictionary.Add("lightseagreen",           new ByteVector3(32,178,170));
        _colorDictionary.Add("darkslategray",           new ByteVector3(47,79,79));
        _colorDictionary.Add("teal",                    new ByteVector3(0,128,128));
        _colorDictionary.Add("darkcyan",                new ByteVector3(0,139,139));
        _colorDictionary.Add("aqua",                    new ByteVector3(0,255,255));
        _colorDictionary.Add("cyan",                    new ByteVector3(0,255,255));
        _colorDictionary.Add("lightcyan",               new ByteVector3(224,255,255));
        _colorDictionary.Add("darkturquoise",           new ByteVector3(0,206,209));
        _colorDictionary.Add("turquoise",               new ByteVector3(64,224,208));
        _colorDictionary.Add("mediumturquoise",         new ByteVector3(72,209,204));
        _colorDictionary.Add("paleturquoise",           new ByteVector3(175,238,238));
        _colorDictionary.Add("aquamarine",              new ByteVector3(127,255,212));
        _colorDictionary.Add("powderblue",              new ByteVector3(176,224,230));
        _colorDictionary.Add("cadetblue",               new ByteVector3(95,158,160));
        _colorDictionary.Add("steelblue",               new ByteVector3(70,130,180));
        _colorDictionary.Add("cornflowerblue",          new ByteVector3(100,149,237));
        _colorDictionary.Add("deepskyblue",             new ByteVector3(0,191,255));
        _colorDictionary.Add("dodgerblue",              new ByteVector3(30,144,255));
        _colorDictionary.Add("lightblue",               new ByteVector3(173,216,230));
        _colorDictionary.Add("skyblue",                 new ByteVector3(135,206,235));
        _colorDictionary.Add("lightskyblue",            new ByteVector3(135,206,250));
        _colorDictionary.Add("midnightblue",            new ByteVector3(25,25,112));
        _colorDictionary.Add("navy",                    new ByteVector3(0,0,128));
        _colorDictionary.Add("darkblue",                new ByteVector3(0,0,139));
        _colorDictionary.Add("mediumblue",              new ByteVector3(0,0,205));
        _colorDictionary.Add("blue",                    new ByteVector3(0,0,255));
        _colorDictionary.Add("royalblue",               new ByteVector3(65,105,225));
        _colorDictionary.Add("blueviolet",              new ByteVector3(138,43,226));
        _colorDictionary.Add("indigo",                  new ByteVector3(75,0,130));
        _colorDictionary.Add("darkslateblue",           new ByteVector3(72,61,139));
        _colorDictionary.Add("slateblue",               new ByteVector3(106,90,205));
        _colorDictionary.Add("mediumslateblue",         new ByteVector3(123,104,238));
        _colorDictionary.Add("mediumpurple",            new ByteVector3(147,112,219));
        _colorDictionary.Add("darkmagenta",             new ByteVector3(139,0,139));
        _colorDictionary.Add("darkviolet",              new ByteVector3(148,0,211));
        _colorDictionary.Add("darkorchid",              new ByteVector3(153,50,204));
        _colorDictionary.Add("mediumorchid",            new ByteVector3(186,85,211));
        _colorDictionary.Add("purple",                  new ByteVector3(128,0,128));
        _colorDictionary.Add("thistle",                 new ByteVector3(216,191,216));
        _colorDictionary.Add("plum",                    new ByteVector3(221,160,221));
        _colorDictionary.Add("violet",                  new ByteVector3(238,130,238));
        _colorDictionary.Add("magenta",                 new ByteVector3(255,0,255));
        _colorDictionary.Add("orchid",                  new ByteVector3(218,112,214));
        _colorDictionary.Add("mediumvioletred",         new ByteVector3(199,21,133));
        _colorDictionary.Add("palevioletred",           new ByteVector3(219,112,147));
        _colorDictionary.Add("deeppink",                new ByteVector3(255,20,147));
        _colorDictionary.Add("hotpink",                 new ByteVector3(255,105,180));
        _colorDictionary.Add("lightpink",               new ByteVector3(255,182,193));
        _colorDictionary.Add("pink",                    new ByteVector3(255,192,203));
        _colorDictionary.Add("antiquewhite",            new ByteVector3(250,235,215));
        _colorDictionary.Add("beige",                   new ByteVector3(245,245,220));
        _colorDictionary.Add("bisque",                  new ByteVector3(255,228,196));
        _colorDictionary.Add("blanchedalmond",	        new ByteVector3(255,235,205));
        _colorDictionary.Add("wheat",                   new ByteVector3(245,222,179));
        _colorDictionary.Add("cornsilk",                new ByteVector3(255,248,220));
        _colorDictionary.Add("lemonchiffon",            new ByteVector3(255,250,205));
        _colorDictionary.Add("lightgoldenrodyellow",    new ByteVector3(250,250,210));
        _colorDictionary.Add("lightyellow",             new ByteVector3(255,255,224));
        _colorDictionary.Add("saddlebrown",             new ByteVector3(139,69,19));
        _colorDictionary.Add("sienna",                  new ByteVector3(160,82,45));
        _colorDictionary.Add("chocolate",               new ByteVector3(210,105,30));
        _colorDictionary.Add("peru",                    new ByteVector3(205,133,63));
        _colorDictionary.Add("sandybrown",              new ByteVector3(244,164,96));
        _colorDictionary.Add("burlywood",               new ByteVector3(222,184,135));
        _colorDictionary.Add("tan",                     new ByteVector3(210,180,140));
        _colorDictionary.Add("rosybrown",               new ByteVector3(188,143,143));
        _colorDictionary.Add("moccasin",                new ByteVector3(255,228,181));
        _colorDictionary.Add("navajowhite",             new ByteVector3(255,222,173));
        _colorDictionary.Add("peachpuff",               new ByteVector3(255,218,185));
        _colorDictionary.Add("mistyrose",               new ByteVector3(255,228,225));
        _colorDictionary.Add("lavenderblush",           new ByteVector3(255,240,245));
        _colorDictionary.Add("linen",                   new ByteVector3(250,240,230));
        _colorDictionary.Add("oldlace",                 new ByteVector3(253,245,230));
        _colorDictionary.Add("papayawhip",              new ByteVector3(255,239,213));
        _colorDictionary.Add("seashell",                new ByteVector3(255,245,238));
        _colorDictionary.Add("mintcream",               new ByteVector3(245,255,250));
        _colorDictionary.Add("slategray",               new ByteVector3(112,128,144));
        _colorDictionary.Add("lightslategray",          new ByteVector3(119,136,153));
        _colorDictionary.Add("lightsteelblue",          new ByteVector3(176,196,222));
        _colorDictionary.Add("lavender",                new ByteVector3(230,230,250));
        _colorDictionary.Add("floralwhite",             new ByteVector3(255,250,240));
        _colorDictionary.Add("aliceblue",               new ByteVector3(240,248,255));
        _colorDictionary.Add("ghostwhite",              new ByteVector3(248,248,255));
        _colorDictionary.Add("honeydew",                new ByteVector3(240,255,240));
        _colorDictionary.Add("ivory",                   new ByteVector3(255,255,240));
        _colorDictionary.Add("azure",                   new ByteVector3(240,255,255));
        _colorDictionary.Add("snow",                    new ByteVector3(255,250,250));
        _colorDictionary.Add("black",                   new ByteVector3(0,0,0));
        _colorDictionary.Add("dimgray",                 new ByteVector3(105,105,105));
        _colorDictionary.Add("gray",	                new ByteVector3(128,128,128));
        _colorDictionary.Add("darkgray",	            new ByteVector3(169,169,169));
        _colorDictionary.Add("silver",	                new ByteVector3(192,192,192));
        _colorDictionary.Add("lightgray",	            new ByteVector3(211,211,211));
        _colorDictionary.Add("gainsboro",               new ByteVector3(220,220,220));
        _colorDictionary.Add("whitesmoke",              new ByteVector3(245,245,245));
        _colorDictionary.Add("white",                   new ByteVector3(255,255,255));
    }
    
    public static ByteVector3 GetColor(string colorName) {
        return _colorDictionary.TryGetValue(colorName, out var color) 
            ? color 
            : ByteVector3.Zero; // Handle the case where the color name is not found (e.g., return a default color)
    }

    public static void AddColor(string colorName, ByteVector3 value) {
        _colorDictionary.TryAdd(colorName, value);
    }
}