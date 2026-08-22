import { useEffect, useState } from "react";
import data from "./data";

const url = "https://course-api.com/react-tabs-project";

export default function App() {
  const [loading, setLoading] = useState(true);
  const [jobs, setJobs] = useState([]);
  const [value, setValue] = useState(0);

  const fetchJobs = async () => {
    setLoading(true);
    try {
      const response = await fetch(url);
      const newJobs = await response.json();
      setJobs(newJobs);
    } catch {
      setJobs(data);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchJobs();
  }, []);

  if (loading) {
    return (
      <section className="section loading">
        <h1>loading...</h1>
      </section>
    );
  }

  return (
    <div>
      {jobs.map((job) => {
        return <div key={job.id}>{job.title}</div>;
      })}
    </div>
  );
}
