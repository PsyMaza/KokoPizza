using KokoPizza.Core.Domain.Common;
using KokoPizza.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KokoPizza.Core.Domain.Entities;

// �������� ������ ���� �������� ������ ��� ������. ��������� ������ ���� ReadOnly ��� ���������� �������.
// �������� ��������� ��� EF.
public class Order : AuditableEntity, IEntity
{
    public Order()
    {
        Items = new HashSet<OrderItem>();
    }

    public Order(string shipAddress, string phoneNumber, long userId, OrderStatus statusId) : this()
    {
        ShipAddress = shipAddress;
        PhoneNumber = phoneNumber;
        UserId = userId;
        StatusId = statusId;
    }

    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //[Column(Order = 1, TypeName = "serial")]
    [Key]
    public long Id { get; set; }

    public OrderStatus StatusId { get; set; }
    
    public ICollection<OrderItem> Items { get; set; }

    public string ShipAddress { get; set; }

    public string PhoneNumber { get; set; }

    public long UserId { get; set; }

    public void AddOrderItem(long productId, int quantity, decimal productPrice)
    {
        var orderItem = new OrderItem(Id, productId, quantity, productPrice);
        Items.Add(orderItem);
    }

    public void SetStatus(OrderStatus status)
    {
        StatusId = status;
    }
}