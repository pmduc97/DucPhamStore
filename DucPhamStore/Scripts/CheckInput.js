function checkInputDangKy() {
    var taikhoan = document.getElementById("taikhoan").value;
    if (taikhoan == null || taikhoan == "") {
        alert("Tài khoản không được để trống");
        return false;
    }

    var matkhau = document.getElementById("matkhau").value;
    if (matkhau == null || matkhau == "") {
        alert("Mật khẩu không được để trống");
        return false;
    }

    var hoten = document.getElementById("hoten").value;
    if (hoten == null || hoten == "") {
        alert("Họ tên không được để trống");
        return false;
    }

    var dienthoai = document.getElementById("dienthoai").value;
    if (dienthoai == null || dienthoai == "") {
        alert("Điện thoại không được để trống");
        return false;
    }

    var email = document.getElementById("email").value;
    if (email == null || email == "") {
        alert("Email không được để trống");
        return false;
    }

    var quequan = document.getElementById("quequan").value;
    if (quequan == null || quequan == "") {
        alert("Quên quán không được để trống");
        return false;
    }
}

function checkSoLuongMua() {

    var t = document.getElementsByClassName("soluong");
    for (var i = 0; i < t.length; i++) {
        if (t[i].value <= 0) {
            alert("Số lượng cần mua không hợp lệ");
            return false;
        }
    }
}

function checkInputCreateLoai() {
    var maLoai = document.getElementById("MaLoai").value;
    var tenLoai = document.getElementById("TenLoai").value;
    if (maLoai == null || maLoai == "") {
        alert("Mã loại không hợp lệ");
        return false;
    }
    if (tenLoai == null || tenLoai == "") {
        alert("Tên loại không hợp lệ");
        return false;
    }
}

function checkInputFind() {
    var key = document.getElementById("key").value;
    if (key == null || key == "") {
        alert("Từ khóa không hợp lệ");
        return false;
    }
}

function checkDelete() {
    if (confirm('Bạn thật sự muốn xóa?')) {
        return true;
    } else {
        return false;
    }
}