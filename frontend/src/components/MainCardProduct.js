import React from 'react';

import MainRating from './MainRating.js';

import { Link } from 'react-router-dom';

export default function MainCardProduct(props) 
{
    const { product, showLink = true } = props;

    return (
        <div key={product._id} className="card">
            <Link to={ showLink ? `/product/${product._id}`: '#'}>
                <img className="medium" src={product.image} alt={product.description} />
                <div className="card-body" >
                    <h2 className="noPadding" >{product.name}</h2>
                    <MainRating rating={product.rating} numReviews={product.numReviews} />
                <div className="card-price" >{Intl.NumberFormat("en-US", {
                                            style: "currency", 
                                            currency: "USD"}).format(Number(product.price))}</div>
            </div>
            </Link>
        </div>
    );
}