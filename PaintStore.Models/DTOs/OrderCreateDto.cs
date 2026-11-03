using System;

namespace PaintStore.Models.DTOs;

//用来描述和保存我们需要的数据
public class OrderCreateDto
{
    public int UserId { get; set; }

    //User Email can be optional. Only required when new user register.
    public string UserEmail { get;set; }

    //User Name can be optional. Only required when new user register.
    public string UserName { get;set; }
    public bool IsNewUser { get;set; }
    public List<int> PaintProductIds { get;set; }
}
