using System.Collections;
using System.Collections.Generic;

namespace Black.Domain.DTO
{
    public class PaginationResponseDTO<T>
    {
        public PaginationResponseDTO(int totalItems, IEnumerable<T> content)
        {
            TotalItems = totalItems;
            Content = content;
        }

        public int TotalItems { get; set; }
        public IEnumerable<T> Content { get; set; }
    }
}
