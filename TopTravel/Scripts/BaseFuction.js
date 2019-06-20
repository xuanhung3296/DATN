function formatnumber(what) {
    var _value = what;
    // do replace dau ' bi chi 1 lan thoi

    _value = _value.replace('.', '');
    _value = _value.replace('.', '');
    _value = _value.replace('.', '');
    var temp = '';
    var test = _value.length;
    var count = 0;
    for (i = test - 1; i >= 0; i--) {
        count++
        temp = _value.charAt(i) + temp;
        if (count % 3 == 0 && i > 0) {
            temp = ',' + temp;
        }
    }
    what = temp;
    return what;
}

function confirmDelete() {
    var con = confirm("Bạn có muốn xóa dữ liệu này không?");
    if (con == true) { return true; }
    else { return false; }
}

//Ham xu ly, chi cho phep go vao nhung ky tu minh muon
function keyRestrict(e, validchars) {
    var key = '', keychar = '';
    key = getKeyCode(e);
    if (key == null) return true;
    keychar = String.fromCharCode(key);
    keychar = keychar.toLowerCase();
    validchars = '-+' + validchars.toLowerCase();
    if (validchars.indexOf(keychar) != -1)
        return true;
    if (key == null || key == 0 || key == 8 || key == 9 || key == 13 || key == 27)
        return true;
    return false;
}

function getKeyCode(e) {
    if (window.event)
        return window.event.keyCode;
    else if (e)
        return e.which;
    else
        return null;
}

function funCheckInt(e) {
    return keyRestrict(e, '0123456789');
}
function setAsHomePage(i) {
    if (document.all) { this.style.behavior = 'url(#default#homepage)'; this.setHomePage('http://www.travel.com.vn/'); }
}
