using Guotong.Api.IRepository;
using Guotong.Api.IService;
using Guotong.Api.Repository;
using System;

namespace Guotong.Api.Service
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository) {
            _testRepository = testRepository;
        }
        public int Sum(int i, int j)
        {
            return _testRepository.Sum(i,j);
        }
    }
}
