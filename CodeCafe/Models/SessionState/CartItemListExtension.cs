using CodeCafe.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCafe.Models.SessionState
{
	public static class CartItemListExtension
	{
		public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
			list.Select(i => new CartItemDTO
			{
				ProductId = i.Product.ProductId,
				Quantity = i.Quantity
			}).ToList();
	}
}
