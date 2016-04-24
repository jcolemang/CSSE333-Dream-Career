using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamCareer
{
    public static class PageRank
    {
        public static Vector RankProfiles()
        {
            int PowerMethodIterations = 50;
            double m = 0.15;

            SparseMatrix A = new SparseMatrix(0, 0);
            A.MultiplyByConstant((1 - m));

            int i;
            for (i = 0; i < PowerMethodIterations; i++)
            {

            }

            return null;
        }

        public static SparseMatrix ConstructLikeMatrix()
        {
            List<int> UserIDs = Database.GetAllUserIDs();
            Dictionary<int, List<int>> UserLikes = new Dictionary<int, List<int>>();
            Dictionary<int, int> UserMatrixColumn = new Dictionary<int, int>();

            int NumUsers = UserIDs.Count;

            int i;
            int id;
            for (i = 0; i < NumUsers; i++)
            {
                id = UserIDs[i];
                UserLikes[id] = Database.GetUserLikes(id);
                UserMatrixColumn[id] = i;
            }

            SparseMatrix LikeMatrix = new SparseMatrix(NumUsers, NumUsers);

            int NumPagesLiked;
            double ContributionFraction;
            int col;
            for (i = 0; i < NumUsers; i++)
            {
                id = UserIDs[i];
                NumPagesLiked = UserLikes[id].Count;
                ContributionFraction = 1.0 / (double)NumPagesLiked;

                foreach (int liked in UserLikes.Keys)
                {
                    col = UserMatrixColumn[liked];
                    LikeMatrix.SetValue(i, col, ContributionFraction);
                }
            }

            return LikeMatrix;
        }

    }
}