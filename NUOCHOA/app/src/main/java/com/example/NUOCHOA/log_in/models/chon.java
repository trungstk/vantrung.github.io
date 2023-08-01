package com.example.NUOCHOA.log_in.models;

public class chon {
    int id_l;
    String loaihang;
    String ten;
    String tien;
    String ghichu;


    public chon(int id_l, String loaihang, String ten, String tien, String ghichu) {
        this.id_l = id_l;
        this.loaihang = loaihang;
        this.ten = ten;
        this.tien = tien;
        this.ghichu = ghichu;
    }

    public String getTien() {
        return tien;
    }

    public int getId_l() {
        return id_l;
    }

    public String getLoaihang() {
        return loaihang;
    }

    public String getTen() {
        return ten;
    }

    public String getGhichu() {
        return ghichu;
    }
}
