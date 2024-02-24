using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        #region Injection

        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<Customer>(customerAddDto);
            await _customerDal.AddAsync(customer);
            await _customerDal.SaveAsync();
            return new SuccessResult(Messages.CustomerAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var customer = await _customerDal.GetAsync(c => c.Id == Id);
            if (customer != null)
            {
                await _customerDal.DeleteAsync(customer);
                await _customerDal.SaveAsync();
                return new SuccessResult(Messages.CustomerDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }
        }

        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            var customers = await _customerDal.GetAllAsync();
            if (customers != null)
            {
                return new SuccessDataResult<List<Customer>>(customers, Messages.CustomerListed);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(null, Messages.CustomerNotFound);
            }
        }

        public async Task<IDataResult<Customer>> GetByIdAsync(int Id)
        {
            var customer = await _customerDal.GetAsync(c => c.Id == Id);
            if (customer != null)
            {
                return new SuccessDataResult<Customer>(customer, Messages.CustomerGeted);
            }
            else
            {
                return new ErrorDataResult<Customer>(null, Messages.CustomerNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var oldCustomer = await _customerDal.GetAsync(c => c.Id == customerUpdateDto.Id);
            if (oldCustomer != null)
            {
                var mappedCustomer = _mapper.Map<CustomerUpdateDto, Customer>(customerUpdateDto, oldCustomer);
                var newCustomer = await _customerDal.UpdateAsync(mappedCustomer);
                await _customerDal.SaveAsync();
                return new SuccessDataResult<Customer>(newCustomer, Messages.CustomerUpdated);
            }
            else
            {
                return new ErrorDataResult<Customer>(null, Messages.CustomerNotFound);
            }
        }
    }
}
