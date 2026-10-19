using System.Diagnostics;

namespace RefactoringLab.Part03.BlockedUsers;

public static class BlockedUserChecker
{
    // Before: List<int>.Contains walks the list -> O(n) per request -> O(n * m) total.
    // After:  HashSet<int>.Contains uses a hash   -> O(1) per request -> O(m) total.
    public static int CountBlocked(HashSet<int> blockedIds, int[] requestIds)
    {
        var blocked = 0;
        foreach (var id in requestIds)
        {
            if (blockedIds.Contains(id))
                blocked++;
        }
        return blocked;
    }

    public static HashSet<int> BuildBlockedIds(int count)
    {
        var set = new HashSet<int>(count);
        for (var i = 0; i < count; i++)
            set.Add(i);
        return set;
    }

    public static int[] BuildRequestIds(int count, int maxId, int seed = 42)
    {
        var rnd = new Random(seed);
        var ids = new int[count];
        for (var i = 0; i < count; i++)
            ids[i] = rnd.Next(maxId);
        return ids;
    }

    public static long MeasureMs(HashSet<int> blockedIds, int[] requestIds, out int found)
    {
        var sw = Stopwatch.StartNew();
        found = CountBlocked(blockedIds, requestIds);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}