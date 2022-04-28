using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerOrderController : ControllerBase
{
    private readonly ICustomerOrderService _customerOrderService;
    public CustomerOrderController(ICustomerOrderService customerOrderService)
    {
        _customerOrderService = customerOrderService;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orderList = _customerOrderService.GetAll();
        return Ok(orderList);

    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _customerOrderService.Get(x=>x.Id==id);
        return Ok(order);

    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(CreateCustomerOrderDto order)
    {
        await _customerOrderService.Add(order);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateOrder(UpdateCustomerOrderDto order, Guid id)
    {

        _customerOrderService.Update(order, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(CustomerOrderDto order)
    {
        _customerOrderService.Delete(order);
        return Ok();
    }
    public IActionResult AddProduct(ProductDto id, ProductDto price, ProductDto quantity)
    {
        //customer id keyi ile bir collection olcak 


    }
    public IActionResult AddDelete(ProductDto id)
    {
        //ürünü tamamenn çıkarma 10 tane varsa 10 da
        //session
    }
    public IActionResult UpdatePrice(ProductDto id,ProductDto newprice)
    {
       //adet değiştirme
       //varsa yeni adeti yaz yoksa bir şey yaoma
    }

    //sipariş verme kısmında ürünü ekle çıkar yaptım adet değiştirdim diğer enpointlerden,
    //adres ve isim girişi default dan başka ad ve adresi gireceği bir endpoimt
    //order da name adres alanaına setle
    //adresi güncelle enpointi eğer varsa kaydı o adresi bul product,name adres geldi
    //ürünler var addres var siparişi tamamla enpointi olucak customer id alıcaz session da tuttuğumuz
    //product koleksiyonu bulucaz order nesnesinde order ıtemlere eşitlicek, orderimn içine tuttuğu name
    //yaz ve siparişi yazıcaz ü
    //hazır olanı databae yaz

    
}

