import Review from "./Review";

export default function App() {
  return (
    <main>
      <section className="container">
        <div className="title">
          <h2>our reviews</h2>
          <div className="underline" />
        </div>
        <Review />
      </section>
    </main>
  );
}
