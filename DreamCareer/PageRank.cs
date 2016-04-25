﻿using System;
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

            SparseMatrix A = ConstructLikeMatrix();

            A.MultiplyByConstant((1 - m));

            int i;
            for (i = 0; i < PowerMethodIterations; i++)
            {
                
            }

            return null;
        }

        public static SparseMatrix ConstructLikeMatrix()
        {
            // just the user ids
            List<int> UserIDs = Database.GetAllUserIDs();

            // stores the likes for each user
            Dictionary<int, List<int>> UserLikes = new Dictionary<int, List<int>>();

            // stores the column in which any given id is stored
            Dictionary<int, int> UserMatrixColumn = new Dictionary<int, int>();

            int NumUsers = UserIDs.Count;

            // building datastructures to easily access each user's likes
            int i;
            int id;
            for (i = 0; i < NumUsers; i++)
            {
                id = UserIDs[i];
                UserLikes[id] = Database.GetUserLikes(id);
                UserMatrixColumn[id] = i;
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
                    col = UserMatrixColumn[liked];
                    LikeMatrix.SetValue(i, col, ContributionFraction);
                }
            }

            return LikeMatrix;
        }

    }
}