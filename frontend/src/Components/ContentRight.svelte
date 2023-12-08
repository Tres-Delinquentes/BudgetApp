<script lang="ts">
  import Cross from "../assets/circle-x.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import { GetLatestIdOfItem } from "./Functions/FetchLatestId.svelte";
  import Chart from "./Chart.svelte";
  export let budget;
  let indexOf;

  $: errorResponse = null;

  async function PostBudgetToApi(budget) {
    fetch("https://localhost:7022/api/Budget", {
      method: "POST",
      body: JSON.stringify(budget),
      headers: {
        "content-Type": "application/json",
      },
    })
      .then(async (r) => {
        if (!r.ok) {
          errorResponse = await r.json();
          console.log("Error occurred:", errorResponse.message);
        } else {
          return r.json();
        }
      })
      .then((responseData) => {
        if (responseData) {
          console.log("Success:", responseData);
        }
      })
      .catch((error) => {
        console.error("Fetch error:", error);
      });
  }

    $: budget.expenses.forEach((expense) => {
    let totalAmount = 0;
    expense.items.forEach((item) => {
      totalAmount += parseFloat(item.amount || 0);
    });
    expense.totalAmount = totalAmount;
  });

  $: totalAmountExpense = budget.expenses.reduce(
    (total, expense) => total + expense.totalAmount,
    0,
  );

  let budgetMessage = "";
  let messageClass = "";

  $: if (budget.income && budget.expenses) {
  const totalIncome = parseFloat(budget.income.totalAmount || 0);
  const totalExpenses = budget.expenses.reduce(
    (total, expense) => total + parseFloat(expense.totalAmount || 0),
    0,
  );

  if (totalIncome === 0 && totalExpenses === 0) {
    budgetMessage = "";
    messageClass = "";
  } else if (totalIncome < totalExpenses) {
    budgetMessage = "Varning!<br>Dina utgifter är högre än din inkomst.";
    messageClass = "message-negative";
  } else if (totalIncome === totalExpenses) {
    budgetMessage = "Balanserad!<br>Din inkomst och utgifter är lika.";
    messageClass = "message-balanced";
  } else {
    budgetMessage = "Bra jobbat!<br>Din inkomst täcker dina utgifter.";
    messageClass = "message-positive";
  }
}

  // $: if (budget.income && budget.expenses) {
  //   const totalIncome = parseFloat(budget.income.totalAmount || 0);
  //   const totalExpenses = budget.expenses.reduce(
  //     (total, expense) => total + parseFloat(expense.totalAmount || 0),
  //     0,
  //   );

  //   if (totalIncome < totalExpenses) {
  //     budgetMessage = "Varning!<br>Dina utgifter är högre än din inkomst.";
  //     messageClass = "message-negative";
  //   } else {
  //     budgetMessage = "Bra jobbat!<br>Din inkomst täcker dina utgifter.";
  //     messageClass = "message-positive";
  //   }
  // }
</script>


  <div class="detail-box mt-3">
    <div class="budget-info">
      <h1 class="subdisplay">{budget.title}</h1>
      {#if budget.description}
      <p class="small-p">{budget.description}</p>
      {/if}
    </div>
    
    <div class="budget-money">
      <h1 class="subdisplay">Din inkomst: {budget.income.totalAmount}kr</h1>
      <h1 class="subdisplay">Dina utgifter: {totalAmountExpense}kr</h1>
    </div>
    
    <p class="message {messageClass}">{@html budgetMessage}</p>
    
    <div class="post-button">
      <button on:click={() => PostBudgetToApi(budget)}>Post Budget</button>
      {#if errorResponse !== null}
      <p>{errorResponse.message}</p>
      {/if}
    </div>
    
  </div>
    <div class="chart">
      <Chart {budget}/>
    </div>
    



<style>

  

  .detail-box {
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
    width: 100%;
    padding: 1rem;
  }

  .chart {
    max-width: 100%;
    height: auto;
    padding: 0 1rem;
    margin: 0.5rem 0;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .budget-info {
    padding: 0 1rem;
    margin: 0 0 0.5rem 0;
    text-align: center;
    max-width: 65ch;
  }

  .budget-money {
    padding: 0 1rem;
    margin: 0.5rem 0;
    text-align: center;
  }

  .post-button {
    padding: 0 1rem;
    margin: 0.5rem 0;
  }
  


  .message {
    width: 50%;
    padding: 0.5rem 1rem;
    border-radius: 4px;
    text-align: center;
    align-self: center;
  }

  .message-negative {
    background-color: #f8d7da;
    color: #721c24;
    border: 1px solid #f6c7cb;
  }

  .message-positive {
    background-color: #d4edda;
    color: #155724;
    border: 1px solid #c3e6cb;
  }

  .message-balanced {
    background-color: #fff3cd;
    color: #856404;
    border: 1px solid #ffeeba;
}

@media (min-width: 768px) {

  .budget-info {
    max-width: 65ch;
  }

  .chart {
    max-width: 100%;
  }

}

@media (min-width: 1024px) {

  .budget-info {
    max-width: 65ch;
  }

  .detail-box {
    margin-bottom: 1rem;
    max-width: 100%;
  }

  .chart {
    max-width: 100%;
  }

  .subdisplay {
    font-size: var(--fs-500);
  }

}

</style>
