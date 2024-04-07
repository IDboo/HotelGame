using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.Customers;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class CustomersController : BaseController
    {

        private readonly ICustomerService _customerService;
        private readonly IFileHelper _fileHelper;

        public CustomersController(IUserAccessor userAccessor, ICustomerService customerService, IFileHelper fileHelper) : base(userAccessor)
        {
            _customerService = customerService;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllAsync();
            if (result != null)
            {
                var customer = new GetAllCustomerViewModel()
                {
                    Customers = result.Data,
                    Message = result.Message
                };
                return View(customer);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAllCustomerViewModel getAllCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new CustomerAddDto()
                {
                    Name = getAllCustomerViewModel.Name,
                    PeopleCount = getAllCustomerViewModel.PeopleCount,
                };

                if (getAllCustomerViewModel.ImageUrl != null)
                {
                    var fileName = getAllCustomerViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    customer.ImageUrl = imageFile;
                }

                var result = await _customerService.AddAsync(customer);
                if (result.Success)
                {
                    return RedirectToAction("GetAllCustomers");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _customerService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllCustomers");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _customerService.GetByIdAsync(Id);
            if (result.Success)
            {
                var customer = new GetAllCustomerViewModel()
                {
                    Name = result.Data.Name,
                    PeopleCount = result.Data.PeopleCount,
                };
                return View(customer);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllCustomerViewModel getAllCustomerViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new CustomerUpdateDto()
                {
                    Id = getAllCustomerViewModel.Id,
                    Name = getAllCustomerViewModel.Name,
                    PeopleCount= getAllCustomerViewModel.PeopleCount
                };

                if (getAllCustomerViewModel.ImageUrl != null)
                {
                    var fileName = getAllCustomerViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _customerService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllCustomers");
                }
                return View();
            }
            return View();
        }
    }

}
