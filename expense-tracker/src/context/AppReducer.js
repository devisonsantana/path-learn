export default (state, action) => {
  switch (action.type) {
    case "DELETE_TRANSACTION":
      const filteredTransactions = state.transactions.filter(
        (transaction) => transaction.id !== action.payload,
      );
      localStorage.setItem(
        "transactions",
        JSON.stringify(filteredTransactions),
      );
      return {
        ...state,
        transactions: filteredTransactions,
      };
    case "ADD_TRANSACTION":
      const newTransactions = [...state.transactions, action.payload];
      localStorage.setItem("transactions", JSON.stringify(newTransactions));
      return {
        ...state,
        transactions: newTransactions,
      };
    default:
      return state;
  }
};
