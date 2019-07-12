package com.dicoding.azureapp

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.bumptech.glide.Glide
import com.bumptech.glide.request.RequestOptions
import kotlinx.android.synthetic.main.item_row_hero.view.*

class ListHeroAdapter(private val listHero: ArrayList<Hero>) : RecyclerView.Adapter<ListHeroAdapter.ViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder =
        ViewHolder(LayoutInflater.from(parent.context).inflate(R.layout.item_row_hero, parent, false))

    override fun getItemCount(): Int = listHero.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.bind(listHero[position])
    }

    inner class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        fun bind(hero: Hero) {
            itemView.tv_hero_name.text = hero.name
            itemView.tv_hero_desc.text = hero.desc
            Glide.with(itemView.context)
                .load(hero.photo)
                .apply(RequestOptions().override(55, 55))
                .into(itemView.iv_hero)
        }
    }
}