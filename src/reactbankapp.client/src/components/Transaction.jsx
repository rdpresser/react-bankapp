import { useEffect, useState } from 'react';
import Header from './Header'

function Transaction() {
    const [data, setData] = useState();

    useEffect(() => {
        populateData();
    }, []);

    const contents = data === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Transaction Type</th>
                    <th>Amount</th>
                    <th>DateTime</th>
                    <th>Document</th>
                </tr>
            </thead>
            <tbody>
                {data.map(item =>
                    <tr key={item.id}>
                        <td>{item.transactionType}</td>
                        <td>{item.amount}</td>
                        <td>{item.dateTime}</td>
                        <td>{item.sourceAccount}</td>
                        <td>{item.destinationAccount}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <Header title='Menu' />
            <h1 id="tableLabel">Transaction List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateData() {
        const response = await fetch('/api/transaction');
        const data = await response.json();
        setData(data);
    }
}

export default Transaction;