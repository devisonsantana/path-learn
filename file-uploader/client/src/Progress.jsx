const Progress = ({ percentage }) => {
  return (
    <div
      className="progress"
      role="progressbar"
      aria-label="Info example"
      aria-valuenow="50"
      aria-valuemin="0"
      aria-valuemax="100"
    >
      <div
        className="progress-bar text-bg-info"
        style={{ width: `${percentage}%` }}
      >
        {percentage}%
      </div>
    </div>
  );
};

export default Progress;
