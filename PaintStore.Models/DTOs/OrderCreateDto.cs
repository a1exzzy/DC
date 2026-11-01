using System;

namespace PaintStore.Models.DTOs;

//用来描述和保存我们需要的数据
public class OrderCreateDto
{
    public int UserId {get; set;}
    public List<int> PaintProductIds {get;set;}
}
