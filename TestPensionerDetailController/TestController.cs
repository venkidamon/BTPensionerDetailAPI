using AutoMapper;
using Moq;
using PensionerDetail.Controllers;
using PensionerDetail.Data;
using PensionerDetail.Dtos;
using PensionerDetail.Repository;

namespace TestPensionerDetailController
{
    public class TestController
    {
        private readonly PensionerDetailController _controller;
        private readonly IPensionerRepository _repository;
        private readonly DataContext _context;
        private readonly IMapper mapper;


        public TestController()
        {
            _repository = new PensionerRepository(_context, mapper);
            _controller = new PensionerDetailController(_repository);
        }
        [Fact]
        public void Test1()
        {
            string aadharNumber = "111111111111";
            var result = _controller.GetPensionerByAadhar(aadharNumber);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test2()
        {
            var result = _controller.GetPensioners();
            Assert.NotNull(result);
        }
        [Fact]
        public void Test3()
        {
            var result = new UserDto();
            result.AadharNumber = "987987987987";
            result.Name = "wire";
            result.DateOfBirth = "01/01/1998";
            result.PanCardNumber = "KIFSD6823O";
            result.Salary = 80000;
            result.Allowance = 6000;
            result.PensionType = "family";
            result.BankType = "private";
            result.BankName = "SBI";
            result.AccountNumber = "000000000000021";
            var restlt1 = _controller.Post(result);
            Assert.NotNull(restlt1);
        }
        [Fact]
        public void Test4()
        {

            string aadharNumber = "987987987987";
            var result = _controller.GetPensionerByAadhar(aadharNumber);
            Assert.NotNull(result);
        }
        


    }
}