using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
namespace POS.UseCases.General.Authentication.RegisterUser
{
    public class RegisterUserUsecase:UseCase
    {
        public UserRegisterDto Dto { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RegisterUserUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        //public async Task<object> Execute()
        //{

        //}
    }
}
