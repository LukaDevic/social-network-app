
var AttendanceService = function () {

    var createAttendance = function (concertId, done, fail) {
        $.post("/api/attendances", { concertId: concertId })
            .done(done)
            .fail(fail);
    };

    var deleteAttendance = function (concertId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + concertId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();