using System.Collections.Generic;

public static class WallKick { //TODO check this matches official SRS
    public static readonly Dictionary<int, Dictionary<(int, int), List<(int, int)>>> Offsets = new Dictionary<int, Dictionary<(int, int), List<(int, int)>>>() {
        // I piece
        { 0, new Dictionary<(int, int), List<(int, int)>>()
            {
                { (0, 1), new List<(int, int)> { (0, 0), (-2, 0), (1, 0), (-2, -1), (1, 2) } },
                { (1, 0), new List<(int, int)> { (0, 0), (2, 0), (-1, 0), (2, 1), (-1, -2) } },
                { (1, 2), new List<(int, int)> { (0, 0), (-1, 0), (2, 0), (-1, 2), (2, -1) } },
                { (2, 1), new List<(int, int)> { (0, 0), (1, 0), (-2, 0), (1, -2), (-2, 1) } },
                { (2, 3), new List<(int, int)> { (0, 0), (2, 0), (-1, 0), (2, 1), (-1, -2) } },
                { (3, 2), new List<(int, int)> { (0, 0), (-2, 0), (1, 0), (-2, -1), (1, 2) } },
                { (3, 0), new List<(int, int)> { (0, 0), (1, 0), (-2, 0), (1, -2), (-2, 1) } },
                { (0, 3), new List<(int, int)> { (0, 0), (-1, 0), (2, 0), (-1, 2), (2, -1) } },
            }
        },
        // All other pieces
        { 1, new Dictionary<(int, int), List<(int, int)>>()
            {
                { (0, 1), new List<(int, int)> { (0, 0), (-1, 0), (-1, 1), (0, -2), (-1, -2) } },
                { (1, 0), new List<(int, int)> { (0, 0), (1, 0), (1, -1), (0, 2), (1, 2) } },
                { (1, 2), new List<(int, int)> { (0, 0), (1, 0), (1, -1), (0, 2), (1, 2) } },
                { (2, 1), new List<(int, int)> { (0, 0), (-1, 0), (-1, 1), (0, -2), (-1, -2) } },
                { (2, 3), new List<(int, int)> { (0, 0), (1, 0), (1, 1), (0, -2), (1, -2) } },
                { (3, 2), new List<(int, int)> { (0, 0), (-1, 0), (-1, -1), (0, 2), (-1, 2) } },
                { (3, 0), new List<(int, int)> { (0, 0), (-1, 0), (-1, -1), (0, 2), (-1, 2) } },
                { (0, 3), new List<(int, int)> { (0, 0), (1, 0), (1, 1), (0, -2), (1, -2) } },
            }
        }
    };
}
