package com.example.NUOCHOA.Home.Tai_khoan.dondamua;

import static com.example.NUOCHOA.Home.Home.chipNavigationBar;

import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;
import androidx.viewpager2.widget.ViewPager2;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

import com.example.NUOCHOA.Home.Trang_chu.trang_chu;
import com.example.NUOCHOA.MainActivity;
import com.example.NUOCHOA.R;
import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;


public class donhangdamua extends Fragment {
    TabLayout tab;
    ViewPager2 viewPager2;

    dondamuaviewpager dondamuaviewpager;
    Button phim1;
    public donhangdamua() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_donhangdamua, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        tab=view.findViewById(R.id.tab);
        viewPager2=view.findViewById(R.id.view);
        phim1=view.findViewById(R.id.phim1);
        phim1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                chipNavigationBar.setVisibility(View.VISIBLE);
                Navigation.findNavController(view).navigate(R.id.action_timkiem2_to_trang_chu);
            }
        });

        dondamuaviewpager=new dondamuaviewpager(this);
        viewPager2.setAdapter(dondamuaviewpager);
        chipNavigationBar.setVisibility(View.GONE);
        new TabLayoutMediator(tab, viewPager2, new TabLayoutMediator.TabConfigurationStrategy() {
            @Override
            public void onConfigureTab(@NonNull TabLayout.Tab tab, int position) {
                switch (position){
                    case 0:
                        tab.setText("Chờ xác nhận ");

                        break;
                    case 1:
                        tab.setText("Đang giao");

                        break;
                    case 2:
                        tab.setText("Đã giao");

                        break;
                    case 3:
                        tab.setText("Đã hủy");
                        break;
                }

            }
        }).attach();
    }
}