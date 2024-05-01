using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRoomMaterial;
using HotelGame.Entities.DTOs.PlayerRoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IPlayerRoomMaterialService
    {
        // Bir oyuncu oda malzemesini getiren fonksiyon
        Task<IDataResult<PlayerRoomMaterial>> GetByIdAsync(int Id);

        // Birden fazla oyuncu oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<PlayerRoomMaterial>>> GetAllAsync();

        // Yeni bir oyuncu oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(PlayerRoomMaterialAddDto playerRoomMaterialAddDto);

        // Bir oyuncu oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(PlayerRoomMaterialUpdateDto playerRoomMaterialUpdateDto);

        // Bir oyuncu oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);

        int LastId();

        IResult Add(PlayerRoomMaterialAddDto playerRoomMaterialAddDto);

        Task<IDataResult<List<PlayerRoomMaterial>>> GetAllByPlayerRoomIdAsync(int playerRoomId);
        Task<IDataResult<PlayerRoomMaterial>> GetUpperLevelMaterial(int playerRoomId);


    }
}
