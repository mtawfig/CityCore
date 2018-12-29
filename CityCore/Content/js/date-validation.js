/**
* Get the number of days in any particular month
* @link https://stackoverflow.com/a/1433119/1293256
* @param  {integer} m The month (valid: 0-11)
* @param  {integer} y The year
* @return {integer}   The number of days in the month
*/
var daysInMonth = function (m, y) {
    switch (m) {
        case 1:
            return (y % 4 == 0 && y % 100) || y % 400 == 0 ? 29 : 28;
        case 8: case 3: case 5: case 10:
            return 30;
        default:
            return 31
    }
};

/**
 * Check if a date is valid
 * @link https://stackoverflow.com/a/1433119/1293256
 * @param  {[type]}  d The day
 * @param  {[type]}  m The month
 * @param  {[type]}  y The year
 * @return {Boolean}   Returns true if valid
 */
var isValidDate = function (str) {
    var arr = str.split("-");
    var y = arr[0];
    var m = arr[1];
    var d = arr[2];

    m = parseInt(arr[1], 10) - 1;
    return m >= 0 && m < 12 && d > 0 && d <= daysInMonth(m, y);
};


function validateDate(oSrc, args) {
    args.IsValid = isValidDate(args);
}