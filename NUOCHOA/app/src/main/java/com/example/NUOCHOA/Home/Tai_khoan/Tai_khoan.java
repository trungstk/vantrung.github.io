package com.example.NUOCHOA.Home.Tai_khoan;

import static com.example.NUOCHOA.Home.Home.idtk;
import static com.example.NUOCHOA.xuly.kiemtra_tt;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.example.NUOCHOA.API.API;
import com.example.NUOCHOA.MainActivity;
import com.example.NUOCHOA.R;
import com.example.NUOCHOA.log_in.models.taikhoan;
import com.ismaeldivita.chipnavigation.ChipNavigationBar;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Tai_khoan extends Fragment {

    TextView ten, email, sdt, diachi, phanhoi;
    LinearLayout layout1, layout2, layout3,layout4;
    ImageView dx;
    Integer tien;
    Integer soluong;

    public Tai_khoan() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_tai_khoan, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ten = view.findViewById(R.id.ten);
        email = view.findViewById(R.id.email);
        sdt = view.findViewById(R.id.sdt);
        diachi = view.findViewById(R.id.diachi);
        layout1 = view.findViewById(R.id.layout1);
        layout2 = view.findViewById(R.id.layout2);
        layout3 = view.findViewById(R.id.layout3);
        phanhoi = view.findViewById(R.id.phanhoi);
        layout4 = view.findViewById(R.id.layout4);
        dx = view.findViewById(R.id.dx);
        layout3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(getContext(), "Chức năng đang bảo trì !", Toast.LENGTH_SHORT).show();
            }
        });
        layout4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
                builder.setTitle("Khách hàng thân thiết");   // Đặt tiêu đề cho dialog
                builder.setMessage("Cảm ơn bạn đã chi tiêu " +tien + "VNĐ " + "và mua "+ soluong + "đơn hàng");  // Đặt nội dung cho dialog
                builder.setCancelable(false);   // Đặt dialog không thể huỷ bỏ bằng phím Back
                builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // Xử lý sự kiện khi người dùng nhấn vào nút OK
                    }
                });
                AlertDialog dialog = builder.create();
                dialog.show();
            }
        });
        phanhoi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(getContext(), "Chức năng đang bảo trì !", Toast.LENGTH_SHORT).show();
            }
        });
        dx.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(getActivity(), MainActivity.class));
                getActivity().finish();
            }
        });
        layout2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Bundle bundle = new Bundle();
                bundle.putInt("ttcn", 0);
                Navigation.findNavController(view).navigate(R.id.action_tai_khoan2_to_thong_tin_ca_nhan, bundle);
            }
        });
        layout1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Navigation.findNavController(view).navigate(R.id.action_tai_khoan2_to_donhangdamua);
            }
        });

        getdata();
    }

    private void getdata() {
        API.API.gettt(idtk).enqueue(new Callback<taikhoan>() {
            @SuppressLint("SetTextI18n")
            @Override
            public void onResponse(Call<taikhoan> call, Response<taikhoan> response) {
                if (response.isSuccessful()) {
                    ten.setText("Họ tên: " + response.body().getHoten());
                    email.setText("Email: " + response.body().getEmail());
                    kiemtra_tt(getContext(), response.body().getSdt(), sdt, response.body().getSdt(), "Thêm số điện thoại", "SĐT: ");
                    kiemtra_tt(getContext(), response.body().getDiachi(), diachi, response.body().getDiachi(), "Thêm địa chỉ", "Địa chỉ: ");
                }
            }

            @Override
            public void onFailure(Call<taikhoan> call, Throwable t) {

            }
        });
        API.API.Get_ThongKe_TaiKhoan_SoLuong(idtk).enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                if (response.isSuccessful()) {
                    soluong  = Integer.valueOf(response.body());

                } else {
                    // Xử lý lỗi nếu có
                }
            }

            @Override
            public void onFailure(Call<String> call, Throwable t) {

            }
        });
        API.API.Get_ThongKe_TaiKhoan_Tien(idtk).enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                if (response.isSuccessful()) {
                    tien  = Integer.valueOf(response.body());

                } else {
                    // Xử lý lỗi nếu có
                }
            }

            @Override
            public void onFailure(Call<String> call, Throwable t) {

            }
        });
    }
}