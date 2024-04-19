using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TopTutor.DataAcess.Data;
using TopTutor.DataAcess.Repository.IRepository;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository
{
    //Author: João Dâmaso
    //This class is responsible for managing the OrderHeader repository
    //It extends the Repository class and implements the IOrderHeaderRepository interface
    //It has a private ApplicationDbContext object
    //It has a constructor that receives an ApplicationDbContext object
    //It has an Update method that receives an OrderHeader object and updates it
    //It has an UpdateStatus method that receives an id, an orderStatus and a paymentStatus and updates the order status and payment status
    //It has an UpdateStripePaymentID method that receives an id, a sessionId and a paymentIntentId and updates the sessionId and paymentIntentId

    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
