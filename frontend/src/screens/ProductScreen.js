import React from 'react';
import ErrorProdutoBuscado from '../components/ErrorProdutoBuscado';
import MainRating from '../components/MainRating';

import { Link, useParams } from 'react-router-dom';

import data from '../data';

export default function ProductScreen() {

    const {id} = useParams();
    const productSearched = data.products.find(x => x.id === id);

    if (!productSearched)
    {
        return <ErrorProdutoBuscado />
    }
    return (
        <div>
            <Link to="/">Back to result</Link>
            <div className="row top">
                <div className="col-1 textAlignCenter">
                    <img className="large" src={productSearched.image} alt={productSearched.name}/>
                </div>
                <div className="row top col-1">
                    <div className="col-1">
                        <ul className="textAlignCenter">
                            <li>
                                <h1>{productSearched.name}</h1>
                            </li>
                            <li>
                                <MainRating rating={productSearched.rating} numReviews={productSearched.numReviews}/>
                            </li>
                            <li>
                                Price : {Intl.NumberFormat("en-US", 
                                    {style: "currency", 
                                    currency: "USD"}).format(Number(productSearched.price)) === '$0.00'? 
                                    'Sem informação'
                                    : Intl.NumberFormat("en-US", 
                                    {style: "currency", 
                                    currency: "USD"}).format(Number(productSearched.price))}
                            </li>
                            <li> Description:
                                <p>{productSearched.description}</p>
                            </li>
                        </ul>
                    </div>
                    <div className="col-1">
                        <div className="card card-body margin-top-1rem" >
                            <ul>
                                <li>
                                    <div className="row">
                                        <div>Price</div>
                                        <div className="card-price">
                                            {Intl.NumberFormat("en-US", {
                                                style: "currency", 
                                                currency: "USD"}).format(Number(productSearched.price))
                                            }
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div className="row">
                                        <div>Status</div>
                                        <div>
                                            {productSearched.stock > 0 ? (
                                                <span className="success">In Stock</span>
                                            ) : (
                                                <span className="danger">Unavailable</span>
                                            )}
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <button className="primary block">Add to Cart</button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
  )
}
