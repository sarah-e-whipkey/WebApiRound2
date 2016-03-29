namespace WebApiRound2.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class BooksController {
        public books;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/books')
                .then((response) => { //on success
                    this.books = response.data;
                })
                .catch((response) => { // on failure
                    console.log(response);
                });
        }
    }

    export class AddBookController {
        public title;
        public author;
        public pageCount;
        public genre;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
        }

       public addBook(book): void {

            this.$http.post('/api/books', book).then((s) => {

                this.$state.go('books');

            }, (e) => { });
        }
    }
}
