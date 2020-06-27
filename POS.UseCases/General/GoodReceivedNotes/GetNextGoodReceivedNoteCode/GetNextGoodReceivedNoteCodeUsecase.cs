using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.GoodReceivedNotes.GetNextGoodReceivedNoteCode
{
    public class GetNextGoodReceivedNoteCodeUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextGoodReceivedNoteCodeUsecase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Execute()
        {
            GoodReceivedNote goodReceivedNote = await unitOfWork.GoodReceivedNotes.GetLastGoodReceivedNote();
            if (goodReceivedNote != null)
            {
                int nextId = goodReceivedNote.Id;
                nextId += 1;
                string result = nextId.ToString().PadLeft(4, '0');
                return $"GRN{result}";
            }
            return "GRN0001";
        }
    }
}
