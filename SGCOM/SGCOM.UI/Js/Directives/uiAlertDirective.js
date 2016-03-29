﻿angular.module("app").directive("uiAlert", function () {
    return {
        templateUrl: "Shared/_Alert.html",
        replace: true,
        restrict: "AE",
        scope: {
            title: "@"
        },
        transclude:true
    }
});