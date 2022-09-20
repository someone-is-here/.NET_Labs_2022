
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WEB_053501_Tatsiana_Shurko.Models {
    public class ListViewModel<T> : List<T> {
        public ListViewModel(){}
        private ListViewModel(List<T> list):base(list) { }
        public static ListViewModel<T> GetModel(IQueryable<T> items, int currentPage, int itemsPerPage, Expression<Func<T, bool>> filter) {
            var list = items.Where(filter).Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage).ToList<T>();
            return new(list);
        }
    }
}
