package com.example.NUOCHOA.Home.Tai_khoan.dondamua;

import static com.example.NUOCHOA.Home.Home.idtk;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Handler;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;

import com.example.NUOCHOA.API.API;
import com.example.NUOCHOA.R;
import com.example.NUOCHOA.log_in.models.donhang;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class dagiao extends Fragment {

    RecyclerView list_item;
    LinearLayout linearLayout;
    dondagiao_adapteter dondagiao_adapteter;
    int sl;
    Handler handler = new Handler();
    Runnable runnable;

    public dagiao() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_dagiao, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        list_item=view.findViewById(R.id.list_item);
        linearLayout=view.findViewById(R.id.layout);
        getdata();
    }
    private void getdata() {
        API.API.getadhllsp(idtk,"Đã giao").enqueue(new Callback<List<donhang>>() {
            @Override
            public void onResponse(Call<List<donhang>> call, Response<List<donhang>> response) {
                if (response.isSuccessful()){
                    linearLayout.setVisibility(View.GONE);
                    list_item.setVisibility(View.VISIBLE);
                    ArrayList<donhang> donhangs= (ArrayList<donhang>) response.body();
                    sl=donhangs.size();
                    dondagiao_adapteter=new dondagiao_adapteter(donhangs,dagiao.this);
                    list_item.setLayoutManager(new LinearLayoutManager(getContext()));
                    list_item.setAdapter(dondagiao_adapteter);
                    dondagiao_adapteter.notifyDataSetChanged();
                }else {
                    linearLayout.setVisibility(View.VISIBLE);
                    list_item.setVisibility(View.GONE);
                }
            }

            @Override
            public void onFailure(Call<List<donhang>> call, Throwable t) {

            }
        });
    }
    @Override
    public void onResume() {
        super.onResume();
        handler.postDelayed( runnable = new Runnable() {
            public void run() {
                API.API.getadhllsp(idtk,"Đã giao").enqueue(new Callback<List<donhang>>() {
                    @Override
                    public void onResponse(Call<List<donhang>> call, Response<List<donhang>> response) {
                        if (response.isSuccessful()){
                            if (response.body().size()< sl){
                                getdata();
                            }
                        }
                    }

                    @Override
                    public void onFailure(Call<List<donhang>> call, Throwable t) {

                    }
                });
                handler.postDelayed(runnable, 2000);
            }
        }, 2000);
    }

    @Override
    public void onPause() {
        super.onPause();
        handler.removeCallbacks(runnable);
    }
}