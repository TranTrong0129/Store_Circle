# Store_Circle

## Hướng dẫn chạy

1. Trước khi chạy cần phải chạy DB (file cippo.sql)  trước trên 1 server nào đấy, SQLserver, mySql, ... (ở đây trương trình chạy Mysql)
2. Sau khi B1 xong có 2 cách để demo chương trình (nếu trong trường hợp c1 chạy không được do cấu hình máy không phù hợp thì chạy c2)
3. Cách 1:
    - vào thư mục  StoreCirle/Debug(Release). tại đây sẽ có file đuôi .exe, ta chạy cài đặt và chờ đợi 
    - Sau khi cài đặt ứng dụng xong, ta chạy chương trình và xuất hiện 1 màn hình kết nối, ta cần nhập ConnectionString cho việc kết nối dữ liệu và ứng dụng( tùy thuộc vào server       cài đặt DB trước đó. (ta tìm kết nối tương ứng ở dây: [ConnectionString](https://www.connectionstrings.com), mysql : [connectionStringMysql](https://www.connectionstrings.com/mysql))
    - Sau khi kết nối xong. kết nối thành công và trải nghiệm.
4. Cách 2:
    - tại thư mục gốc ban đầu. có file CIPO app.sln và ta chạy lên. (phương pháp này chạy cho người phát triển)
    - Sau khi chương trình được mở. Chạy Ctrl+ f5 để chạy chương trình.
    - Chương trình xuất hiện hộp thoại kết nối giống cách 1 và tiến hành các bước sau như cách 1 và trải nghiệm
