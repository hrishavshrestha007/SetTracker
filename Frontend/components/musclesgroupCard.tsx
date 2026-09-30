'use client';


import { getMuscleGroups, MuscleGroup } from "@/services/muscleGroupServices";
import Link from "next/link";
import { useEffect, useState } from "react";

export default function MuscleGroupCards() {
  const [muscleGroups, setMuscleGroups] = useState<MuscleGroup[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function fetchMuscleGroups() {
      try {
        const groups = await getMuscleGroups();
        setMuscleGroups(groups);
      } catch (err) {
        setError("Failed to load muscle groups");
      } finally {
        setLoading(false);
      }
    }

    fetchMuscleGroups();
  }, []);

  if (loading) return <p className="text-slate-300">Loading...</p>;
  if (error) return <p className="text-rose-400">{error}</p>;

  const muscleEmojis: Record<string, string> = {
    chest: "💯",
    back: "🏋️",
    legs: "🦵",
    arms: "💪",
    shoulders: "🤸",
    core: "⚙️",
  };

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      {muscleGroups.map((group) => (
        <Link
          key={group.id}
          href={`/exercises?group=${group.name.charAt(0).toUpperCase() + group.name.slice(1)}`}
        >
          <div className="group relative h-40 rounded-2xl backdrop-blur-xl bg-white/5 border border-white/10 hover:border-white/20 p-8 flex flex-col justify-between transition-all duration-300 hover:bg-white/10 cursor-pointer">
            <div className="absolute inset-0 bg-gradient-to-r from-sky-500 to-cyan-500 rounded-2xl opacity-0 group-hover:opacity-20 blur-xl transition-all duration-300"></div>
            
            <div className="relative">
              <div className="text-4xl mb-3">{muscleEmojis[group.name.toLowerCase()] || "💪"}</div>
              <h3 className="text-2xl font-bold text-white capitalize">{group.name}</h3>
            </div>

            <div className="relative text-sky-400 font-semibold flex items-center gap-2">
              View Exercises <span>→</span>
            </div>
          </div>
        </Link>
      ))}
    </div>
  );
}