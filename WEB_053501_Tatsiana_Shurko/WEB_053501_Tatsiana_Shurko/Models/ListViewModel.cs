
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WEB_053501_Tatsiana_Shurko.Models {
    public class ListViewModel<T> : List<T> {
        public static decimal TotalPages { get; set; }
        public static int CurrentPage { get; set; }
        public static int AmountPerPage { get; set; }
        public static int GroupId { get; set; }

        public ListViewModel(){}
        private ListViewModel(List<T> list):base(list) { }
        public static ListViewModel<T> GetModel(IQueryable<T> items, int currentPage, Expression<Func<T, bool>> filter) {
            CurrentPage = currentPage;
            var list = items.Where(filter).Skip((currentPage - 1) * AmountPerPage).Take(AmountPerPage).ToList<T>();

            return new(list);
        }
    }
}
