'use strict';

angular.module('app.directives', [])
    // This is used for masking input boxes
    .directive('mask', function () {
        return {
            restrict: 'A',
            link: function (scope, elem, attr, ctrl) {
                if (attr.mask)
                    elem.mask(attr.mask, { placeholder: attr.maskPlaceholder });
            }
        };
    });