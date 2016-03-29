namespace WebApiRound2 {

    angular.module('WebApiRound2', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/home.html',
                controller: WebApiRound2.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/about.html',
                controller: WebApiRound2.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('books', {
                url: '/books',
                templateUrl: '/ngApp/books.html',
                controller: WebApiRound2.Controllers.BooksController,
                controllerAs: 'controller'
            })
            .state('addBook', {
                url: '/addBook',
                templateUrl: '/ngApp/addBook.html',
                controller: WebApiRound2.Controllers.AddBookController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

}
