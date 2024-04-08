using Autofac;
using HotelGame.Business.Abstract;
using HotelGame.Business.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntitiyFramework;
using HotelGame.DataAccess.Concrete.EntityFramework;
using HotelGame.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelGameContext>().As<DbContext>().SingleInstance();

            // Varlık ve Servis eşleştirmeleri
            builder.RegisterType<AuthenticationManager>().As<IAuthenticationService>();

            builder.RegisterType<EfHotelTypeDal>().As<IHotelTypeDal>();
            builder.RegisterType<HotelTypeManager>().As<IHotelTypeService>();

            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();

            builder.RegisterType<EfHotelPositionDal>().As<IHotelPositionDal>();
            builder.RegisterType<HotelPositionManager>().As<IHotelPositionService>();

            builder.RegisterType<EfPlayerHotelDal>().As<IPlayerHotelDal>();
            builder.RegisterType<PlayerHotelManager>().As<IPlayerHotelService>();

            builder.RegisterType<EfPlayerHotelPositionDal>().As<IPlayerHotelPositionDal>();
            builder.RegisterType<PlayerHotelPositionManager>().As<IPlayerHotelPositionService>();

            builder.RegisterType<EfPlayerRoomDal>().As<IPlayerRoomDal>();
            builder.RegisterType<PlayerRoomManager>().As<IPlayerRoomService>();

            builder.RegisterType<EfPlayerRoomMaterialDal>().As<IPlayerRoomMaterialDal>();
            builder.RegisterType<PlayerRoomMaterialManager>().As<IPlayerRoomMaterialService>();

            builder.RegisterType<EfRoomMaterialDal>().As<IRoomMaterialDal>();
            builder.RegisterType<RoomMaterialManager>().As<IRoomMaterialService>();

            builder.RegisterType<EfRoomTypeDal>().As<IRoomTypeDal>();
            builder.RegisterType<RoomTypeManager>().As<IRoomTypeService>();

            builder.RegisterType<EfStaffDal>().As<IStaffDal>();
            builder.RegisterType<StaffManager>().As<IStaffService>();

            builder.RegisterType<EfBookingDal>().As<IBookingDal>();
            builder.RegisterType<BookingManager>().As<IBookingService>();

            builder.RegisterType<EfPlayerHotelStaffDal>().As<IPlayerHotelStaffDal>();
            builder.RegisterType<PlayerHotelStaffManager>().As<IPlayerHotelStaffService>();

            builder.RegisterType<EfMultiplierDal>().As<IMultiplierDal>();
            builder.RegisterType<MultiplierManager>().As<IMultiplierService>();

            builder.RegisterType<AutoCreaterManager>().As<IAutoCreaterService>();

        }
    }
}
