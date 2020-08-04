using Guotong.Api.IRepository;
using System;

namespace Guotong.Api.Repository
{
    public class TestRepository : ITestRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
