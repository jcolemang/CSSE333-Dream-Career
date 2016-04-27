using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamCareer
{
    public static class PageRank
    {
        public static List<int> RankProfiles(int NumberToReturn)
        {
            int PowerMethodIterations = 75;
            double m = 0.15;

            // just the user ids
            List<int> UserIDs = Database.GetAllUserIDs();

            // stores the likes for each user
            Dictionary<int, List<int>> UserLikes = new Dictionary<int, List<int>>();


            // The matrix we care about
            SparseMatrix A = ConstructLikeMatrix(UserIDs, UserLikes);

            // For the theoretical matrix S (We just store the constant)
            double s = 1 / A.Rows;

            // M = (1-m)A + mS, this is (1-m)A
            A.MultiplyByConstant((1 - m));

            // The 'random' vector for the power method
            Vector v = new Vector(A.Rows);
            int i;
            for (i = 0; i < v.Rows; i++)
                v.Values[i] = 1;

            // the power method to get the largest eigenvector of M
            for (i = 0; i < PowerMethodIterations; i++)
            {
                // Mv = (1-m)Av + mSv = (1-m)Av + ms
                // The last step is only valid if the rows of v add up to 1.
                // I can make this assumption because I normalize it every 
                // step using the one norm, which is by definition the sum 
                // of the rows.
                // A was multiplied by (1-m) above.
                v = A.MultiplyOnRight(v);
                v.AddConstant(m * s);
                v.Normalize();
            }

            SortedDictionary<double, int> ImportanceScores = new SortedDictionary<double, int>();
            double MinValue = 0;
            for (i = 0; i < v.Rows; i++)
            {
                if (ImportanceScores.Count < NumberToReturn)
                    ImportanceScores.Add(v.GetValue(i), UserIDs[i]);
                else if (v.GetValue(i) > MinValue)
                {
                    ImportanceScores.Add(v.GetValue(i), UserIDs[i]);
                    MinValue = ImportanceScores.Keys.Min();
                }
            }

            List<int> MostImportant = new List<int>();
            double[] HighestScores = ImportanceScores.Keys.ToArray<double>();
            double dummy;
            int n = ImportanceScores.Count < NumberToReturn ? ImportanceScores.Count : NumberToReturn;
            for (i = 0; i < n; i++)
            {
                dummy = HighestScores[i]; 
            }

            return MostImportant;

        }

        public static SparseMatrix ConstructLikeMatrix(List<int> UserIDs, Dictionary<int, 
            List<int>> UserLikes)
        {
            int NumUsers = UserIDs.Count;

            // stores the column in which any given id is stored
            Dictionary<int, int> UserInColumn = new Dictionary<int, int>();

            // building datastructures to easily access each user's likes
            int i;
            int id;
            for (i = 0; i < NumUsers; i++)
            {
                id = UserIDs[i];
                UserLikes[id] = Database.GetUserLikes(id);
                UserInColumn[id] = i;
            }

            // the good stuff
            SparseMatrix LikeMatrix = new SparseMatrix(NumUsers, NumUsers);

            int NumPagesLiked;
            double ContributionFraction;
            int col;
            for (i = 0; i < NumUsers; i++)
            {
                id = UserIDs[i];
                NumPagesLiked = UserLikes[id].Count;

                if (NumPagesLiked == 0)
                    continue; // sparse matrix implicitly sets all values to 0

                ContributionFraction = 1.0 / (double)NumPagesLiked;

                foreach (int liked in UserLikes.Keys)
                {
                    col = UserInColumn[liked];
                    LikeMatrix.SetValue(i, col, ContributionFraction);
                }
            }

            return LikeMatrix;
        }

    }
}