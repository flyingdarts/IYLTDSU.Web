function getCode() {
    if (window.location.search.indexOf("code") > -1) {
        var params = new URLSearchParams(window.location.search).get("code");
        return { "code": params }
    }
}