using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.GoodReceivedNotes.GetGoodReceivedNoteFullInfo
{
    public class GetGoodReceivedNoteFullInfoUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetGoodReceivedNoteFullInfoUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GrnWithFullInfoDto> Execute()
        {
            GoodReceivedNote grnModel = await unitOfWork.GoodReceivedNotes.GetGoodReceivedNoteWithFullInfo(Id);
            GrnWithFullInfoDto result = mapper.Map<GoodReceivedNote, GrnWithFullInfoDto>(grnModel);
            return result;
        }
    }
}
